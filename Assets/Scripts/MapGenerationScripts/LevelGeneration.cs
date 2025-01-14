using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Vector2 worldsize = new Vector2(4, 4);
    Room[,] rooms;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridsizeX, gridsizeY;
    public int numberOfRooms = 20;

    public int normalRoomChance;
    public int TreasuryChance;

    public GameObject roomWhiteObj;

    public DualGridTilemap wallLayer;
    public DualGridTilemap groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        if (numberOfRooms >= (worldsize.x * 2) * (worldsize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt((worldsize.x * 2) * (worldsize.y * 2));
        }

        gridsizeX = Mathf.RoundToInt(worldsize.x);
        gridsizeY = Mathf.RoundToInt(worldsize.y);
        CreateRooms();
        SetRoomDoors();
        DrawMap();
        GetComponent<SheetAssigner>().Assign(rooms);

        wallLayer.enabled = true;
        groundLayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRooms()
    {
        rooms = new Room[gridsizeX * 2, gridsizeY * 2];
        rooms[gridsizeX, gridsizeY] = new Room(Vector2.zero, 0);
        takenPositions.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;

        for (int i = 0; i < numberOfRooms - 1; i++)
        {
            float randomPerc = ((float)i) / (((float)numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);

            checkPos = NewPosition();



            if (NumberOfNeighbors(checkPos, takenPositions) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectiveNewPosition();
                    iterations++;
                } while (NumberOfNeighbors(checkPos, takenPositions) > 1 && iterations > 100);
                {
                    if (iterations >= 50)
                    {
                        print("Error: could not create with fewer neighbors than : " + NumberOfNeighbors(checkPos, takenPositions));
                    }
                }
            }

            rooms[(int)checkPos.x + gridsizeX, (int)checkPos.y + gridsizeY] = new Room(checkPos, SetRoomType(i));
            takenPositions.Insert(0, checkPos);
        }
    }

    int SetRoomType(int count)
    {
        int type = 1;

        if (count == 4)
        {
            type = 2;
        }
        else if (count == 9)
        {
            type = 2;
        }
        else if (count == 15)
        {
            type = 2;
        }
        else if (count == 18)
        {
            type = 3;
        }
        else
        {
            int range = normalRoomChance + TreasuryChance;
            int rng = Random.Range(0, range);

            if (rng > normalRoomChance - 1 && rng <= range)
            {
                type = 2;
            }
        }

        return type;
    }

    void SetRoomDoors()
    {
        for (int x = 0; x < ((gridsizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridsizeY * 2)); y++)
            {
                if (rooms[x, y] == null)
                {
                    continue;
                }

                Vector2 gridPosition = new Vector2(x, y);

                if (y - 1 < 0)
                {
                    rooms[x, y].doorBot = false;
                }
                else
                {
                    rooms[x, y].doorBot = (rooms[x, y - 1] != null);
                }
                if (y + 1 >= gridsizeY * 2)
                {
                    rooms[x, y].doorTop = false;
                }
                else
                {
                    rooms[x, y].doorTop = (rooms[x, y + 1] != null);
                }
                if (x - 1 < 0)
                {
                    rooms[x, y].doorLeft = false;
                }
                else
                {
                    rooms[x, y].doorLeft = (rooms[x - 1, y] != null);
                }
                if (x + 1 >= gridsizeX * 2)
                {
                    rooms[x, y].doorRight = false;
                }
                else
                {
                    rooms[x, y].doorRight = (rooms[x + 1, y] != null);
                }
            }
        }
    }

    void DrawMap()
    {
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector2 drawPos = room.gridPos;
            drawPos.x *= 1;
            drawPos.y *= 1;
            MapSpriteSelector mapper = Object.Instantiate(roomWhiteObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
            mapper.type = room.type;
            mapper.up = room.doorTop;
            mapper.down = room.doorBot;
            mapper.right = room.doorRight;
            mapper.left = room.doorLeft;
        }
    }

    Vector2 NewPosition()
    {
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            bool upDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }

            checkingPos = new Vector2(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridsizeX || x < -gridsizeX || y >= gridsizeY || y < -gridsizeY);

        return checkingPos;
    }

    Vector2 SelectiveNewPosition()
    {
        int index = 0, inc = 0;
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;

        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            } while (NumberOfNeighbors(takenPositions[index], takenPositions) > 1 && inc < 100);

            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            bool upDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }

            checkingPos = new Vector2(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridsizeX || x < -gridsizeX || y >= gridsizeY || y < -gridsizeY);

        if (inc >= 100)
        {
            print("Error: could not find position with only one neighbor");
        }
            
        return checkingPos;
    }

    int NumberOfNeighbors(Vector2 checkingPos, List<Vector2> usedPositions)
    {
        int ret = 0;
        if (usedPositions.Contains(checkingPos + Vector2.right))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.left))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.up))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.down))
        {
            ret++;
        }
        return ret;
    }
}
