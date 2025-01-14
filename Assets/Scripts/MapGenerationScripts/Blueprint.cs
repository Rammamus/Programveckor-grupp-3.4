using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Blueprint : MonoBehaviour
{
    public BoundsInt area;

    public TileBase[] wallLayer;
    public TileBase[] groundlayer;
    public TileBase[] decorationlayer;
}
