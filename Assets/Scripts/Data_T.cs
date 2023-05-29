using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_T : MonoBehaviour
{
    //List of 8 dictionaries from Tile_TL to Tile_L clockwise
    public List<Dictionary<int, int>> tilePairs = new List<Dictionary<int, int>>();

    private void Start()
    {
        tilePairs[0][10] = 12;
        tilePairs[0][10] = 13;
        tilePairs[0][10] = 14;
        tilePairs[0][10] = 15;
        tilePairs[0][10] = 16;
        tilePairs[0][10] = 17;
        tilePairs[0][10] = 18;
        tilePairs[0][10] = 19;
    }
}
