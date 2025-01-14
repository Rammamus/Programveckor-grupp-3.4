using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomInstance : MonoBehaviour
{
	public Blueprint blueprint;

    [HideInInspector]
	public Vector2 gridPos;
	public int type; // 0: start, 1: normal, 2: treasury, 3: boss

	private Tilemap wallLayer;
	private Tilemap groundLayer;
	private Tilemap decorationLayer;

    private BoundsInt area;

	public void Setup(Vector2 _gridPos, int _type, Tilemap _wallLayer, Tilemap _groundLayer, Tilemap _decorationLayer)
	{
		gridPos = _gridPos;
		type = _type;
		wallLayer = _wallLayer;
		groundLayer = _groundLayer;
		decorationLayer = _decorationLayer;
		GenerateRoomTiles();
	}

	void GenerateRoomTiles()
	{
		area = blueprint.area;
		area.x += Mathf.RoundToInt(gridPos.x);
        area.y += Mathf.RoundToInt(gridPos.y);

		wallLayer.SetTilesBlock(area, blueprint.wallLayer);
        groundLayer.SetTilesBlock(area, blueprint.groundlayer);
        decorationLayer.SetTilesBlock(area, blueprint.decorationlayer);
    }
}
