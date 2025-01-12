using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Blueprint : ScriptableObject
{
    public BoundsInt area;

    public TileBase[] wallLayer;
    public TileBase[] groundlayer;
    public TileBase[] decorationlayer;
}
