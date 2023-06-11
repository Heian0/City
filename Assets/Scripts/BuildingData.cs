using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
    [System.Serializable]
    public class Container
    {
        public List<int> list;
    }

    public List<Container> layout;

    public int id;
    public int w;
    public int h;

    //0 grass, 1 sand, 99 null
    public int groundCode;

    public List<TileBase> buildingTiles;
}
