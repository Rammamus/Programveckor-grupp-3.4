using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetup : MonoBehaviour
{
    public string NextDoor;
    public float distance;
    public float offset;
    public GameObject door;
    public LayerMask layerMask;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        GetDirection();
        GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetDirection()
    {
        if (door.name == "DoorU")
        {
            direction = new Vector2(0, 1);
        }
        else if (door.name == "DoorD")
        {
            direction = new Vector2(0, -1);
        }
        else if (door.name == "DoorL")
        {
            direction = new Vector2(-1, 0);
        }
        else if (door.name == "DoorR")
        {
            direction = new Vector2(1, 0);
        }
    }

    void GetDistance()
    {
        RaycastHit2D hit = Physics2D.Raycast(door.transform.position, direction, 100, layerMask);
        if (hit.collider != null)
        {
            distance = hit.distance + offset;
        }
        else
        {
            Destroy(door);
        }
    }
}