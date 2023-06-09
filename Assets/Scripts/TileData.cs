using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase tile;

    public bool canPlaceBuilding;

    //0 grass, 1 sand
    public int groundCode;

    public int id;
}
