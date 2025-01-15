using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SheetAssigner : MonoBehaviour
{
    public Tilemap wallLayer;
    public Tilemap groundlayer;
    public Tilemap decorationlayer;

	public GameObject[] RoomsStart, RoomsNormal, RoomsTreasury, RoomsBoss;
	public Vector2 roomDimensions = new Vector2(100, 100);

	private GameObject currentRoom;

	public void Assign(Room[,] rooms)
	{
		foreach (Room room in rooms)
		{
			//skip point where there is no room
			if (room == null){
				continue;
			}

			if (room.type == 0)
			{
				//pick a random index for the array
				int index = Mathf.RoundToInt(Random.value * (RoomsStart.Length - 1));
				print("start " + index);
				currentRoom = RoomsStart[index];
			}
			else if (room.type == 1)
			{
				//pick a random index for the array
				int index = Mathf.RoundToInt(Random.value * (RoomsNormal.Length - 1));
                print("normal " + index);
                currentRoom = RoomsNormal[index];
			}
            else if (room.type == 2)
            {
                //pick a random index for the array
                int index = Mathf.RoundToInt(Random.value * (RoomsTreasury.Length - 1));
                print("treasury " + index);
                currentRoom = RoomsTreasury[index];
            }
            else if (room.type == 3)
            {
                //pick a random index for the array
                int index = Mathf.RoundToInt(Random.value * (RoomsBoss.Length - 1));
                print("boss " + index);
                currentRoom = RoomsBoss[index];
            }

            //find position to place room
            Vector3 pos = new Vector3(room.gridPos.x * roomDimensions.x, room.gridPos.y * roomDimensions.y, 0);
			RoomInstance myRoom = Instantiate(currentRoom, pos, Quaternion.identity).GetComponent<RoomInstance>();
			myRoom.Setup(pos, room.type, wallLayer, groundlayer, decorationlayer);
		}
	}
}
