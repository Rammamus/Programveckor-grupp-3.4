using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomInstance : MonoBehaviour
{
	//public Blueprint blueprint;

    [HideInInspector]
	public Vector2 gridPos;
	public int type; // 0: start, 1: normal, 2: treasury, 3: boss

	public void Setup(Vector2 _gridPos, int _type)
	{
		gridPos = _gridPos;
		type = _type;
    }
}
