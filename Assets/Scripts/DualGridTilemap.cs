using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;
using static TileType;

public class DualGridTilemap : MonoBehaviour {
    protected static Vector3Int[] NEIGHBOURS = new Vector3Int[] {
        new Vector3Int(0, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 1, 0)
    };

    protected static Dictionary<Tuple<TileType, TileType, TileType, TileType>, Tile> neighbourTupleToTile;

    // Provide references to each tilemap in the inspector
    public Tilemap placeholderTilemap;
    public Tilemap displayTilemap;

    // Provide the dirt and grass placeholder tiles in the inspector
    public Tile groundPlaceholderTile;
    public Tile wallPlaceholderTile;

    // Provide the 16 tiles in the inspector
    public Tile[] tiles;

    void Start() {
        // This dictionary stores the "rules", each 4-neighbour configuration corresponds to a tile
        // |_1_|_2_|
        // |_3_|_4_|
        neighbourTupleToTile = new() {
            {new (Ground, Ground, Ground, Ground), tiles[6]},
            {new (Wall, Wall, Wall, Ground), tiles[13]}, // OUTER_BOTTOM_RIGHT
            {new (Wall, Wall, Ground, Wall), tiles[0]}, // OUTER_BOTTOM_LEFT
            {new (Wall, Ground, Wall, Wall), tiles[8]}, // OUTER_TOP_RIGHT
            {new (Ground, Wall, Wall, Wall), tiles[15]}, // OUTER_TOP_LEFT
            {new (Wall, Ground, Wall, Ground), tiles[1]}, // EDGE_RIGHT
            {new (Ground, Wall, Ground, Wall), tiles[11]}, // EDGE_LEFT
            {new (Wall, Wall, Ground, Ground), tiles[3]}, // EDGE_BOTTOM
            {new (Ground, Ground, Wall, Wall), tiles[9]}, // EDGE_TOP
            {new (Wall, Ground, Ground, Ground), tiles[5]}, // INNER_BOTTOM_RIGHT
            {new (Ground, Wall, Ground, Ground), tiles[2]}, // INNER_BOTTOM_LEFT
            {new (Ground, Ground, Wall, Ground), tiles[10]}, // INNER_TOP_RIGHT
            {new (Ground, Ground, Ground, Wall), tiles[7]}, // INNER_TOP_LEFT
            {new (Wall, Ground, Ground, Wall), tiles[14]}, // DUAL_UP_RIGHT
            {new (Ground, Wall, Wall, Ground), tiles[4]}, // DUAL_DOWN_RIGHT
            {new (Wall, Wall, Wall, Wall), tiles[12]},
        };
        RefreshDisplayTilemap();
    }

    public void SetCell(Vector3Int coords, Tile tile) {
        placeholderTilemap.SetTile(coords, tile);
        setDisplayTile(coords);
    }

    private TileType getPlaceholderTileTypeAt(Vector3Int coords) {
        if (placeholderTilemap.GetTile(coords) == groundPlaceholderTile)
            return Ground;
        else
            return Wall;
    }

    protected Tile calculateDisplayTile(Vector3Int coords) {
        // 4 neighbours
        TileType topRight = getPlaceholderTileTypeAt(coords - NEIGHBOURS[0]);
        TileType topLeft = getPlaceholderTileTypeAt(coords - NEIGHBOURS[1]);
        TileType botRight = getPlaceholderTileTypeAt(coords - NEIGHBOURS[2]);
        TileType botLeft = getPlaceholderTileTypeAt(coords - NEIGHBOURS[3]);

        Tuple<TileType, TileType, TileType, TileType> neighbourTuple = new(topLeft, topRight, botLeft, botRight);

        return neighbourTupleToTile[neighbourTuple];
    }

    protected void setDisplayTile(Vector3Int pos) {
        for (int i = 0; i < NEIGHBOURS.Length; i++) {
            Vector3Int newPos = pos + NEIGHBOURS[i];
            displayTilemap.SetTile(newPos, calculateDisplayTile(newPos));
        }
    }

    // The tiles on the display tilemap will recalculate themselves based on the placeholder tilemap
    public void RefreshDisplayTilemap() {
        for (int i = -50; i < 50; i++) {
            for (int j = -50; j < 50; j++) {
                setDisplayTile(new Vector3Int(i, j, 0));
            }
        }
    }
}

public enum TileType {
    None,
    Ground,
    Wall
}
