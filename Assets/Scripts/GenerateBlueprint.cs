using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateBlueprint : MonoBehaviour
{
    public bool saveBlueprint = false;
    public bool loadBlueprint = false;
    public bool clear = false;

    public Blueprint blueprint;

    public BoundsInt area;
    public Tilemap wallLayer;
    public Tilemap groundlayer;
    public Tilemap decorationlayer;

    public DualGridTilemap wallTilemap;
    public DualGridTilemap groundTilemap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (saveBlueprint)
        {
            wallLayer.CompressBounds();
            groundlayer.CompressBounds();
            decorationlayer.CompressBounds();

            print(wallLayer.localBounds);
            print(wallLayer.origin);
            print(wallLayer.size);

            area.size = wallLayer.size;
            area.position = wallLayer.origin;

            blueprint.wallLayer = wallLayer.GetTilesBlock(area);
            blueprint.groundlayer = groundlayer.GetTilesBlock(area);
            blueprint.decorationlayer = decorationlayer.GetTilesBlock(area);
            blueprint.area = area;

            saveBlueprint = false;
        }

        if (loadBlueprint)
        {
            wallLayer.SetTilesBlock(blueprint.area, blueprint.wallLayer);
            groundlayer.SetTilesBlock(blueprint.area, blueprint.groundlayer);
            decorationlayer.SetTilesBlock(blueprint.area, blueprint.decorationlayer);

            wallTilemap.RefreshDisplayTilemap();
            groundTilemap.RefreshDisplayTilemap();

            loadBlueprint = false;
        }

        if (clear)
        {
            wallLayer.ClearAllTiles();
            groundlayer.ClearAllTiles();
            decorationlayer.ClearAllTiles();

            wallTilemap.RefreshDisplayTilemap();
            groundTilemap.RefreshDisplayTilemap();

            clear = false;
        }
    }
}
