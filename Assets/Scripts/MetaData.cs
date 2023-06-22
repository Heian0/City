using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class MetaData : MonoBehaviour
{
    [SerializeField]
    public Tilemap map;

    [SerializeField]
    public Tilemap buildingMap;

    [SerializeField]
    public List<TileData> tileDatas;

    [SerializeField]
    public List<BuildingData> buildingDatas;

    public Dictionary<TileBase, TileData> dataFromBase = new Dictionary<TileBase, TileData>();

    public int gold;

    public TMP_Text goldCounter;
    public ShopItem_N curItem;

    public int selectedID;
    public string selectedType;
    public int cost;

    //0-tl, 1-t, 2-tr, 3-r, 4-br, 5-b, 6-bl, 7-l
    public List<Dictionary<(int, int), int>> tileDictList = new List<Dictionary<(int, int), int>>();
    private Dictionary<(int, int), int> tileDict_tl = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_t = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_tr = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_r = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_br = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_b = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_bl = new Dictionary<(int, int), int>();
    private Dictionary<(int, int), int> tileDict_l = new Dictionary<(int, int), int>();

    void Start()
    {
        goldCounter.text = gold.ToString() + " Gold";

        foreach (var tileData in tileDatas)
        {
            dataFromBase.Add(tileData.tile, tileData);
        }

        tileDict_tl.Add((200, 100), 201);
        tileDict_tl.Add((200, 202), 202);
        tileDict_tl.Add((200, 200), 200);
        tileDict_tl.Add((200, 210), 210);
        tileDict_tl.Add((200, 203), 202);
        tileDict_tl.Add((200, 208), 208);
        tileDict_tl.Add((200, 204), 210);
        tileDict_tl.Add((200, 207), 208);
        tileDict_tl.Add((200, 212), 212);
        tileDict_tl.Add((200, 211), 200);
        tileDict_tl.Add((200, 209), 209);
        tileDict_tl.Add((200, 206), 212);
        tileDictList.Add(tileDict_tl);

        tileDict_t.Add((200, 100), 202);
        tileDict_t.Add((200, 203), 202);
        tileDict_t.Add((200, 201), 202);
        tileDict_t.Add((200, 204), 210);
        tileDict_t.Add((200, 208), 209);
        tileDict_t.Add((200, 200), 200);
        tileDict_t.Add((200, 212), 200);
        tileDict_t.Add((200, 211), 200);
        tileDict_t.Add((200, 206), 200);
        tileDictList.Add(tileDict_t);

        tileDict_tr.Add((200, 100), 203);
        tileDict_tr.Add((200, 202), 202);
        tileDict_tr.Add((200, 209), 209);
        tileDict_tr.Add((200, 200), 200);
        tileDict_tr.Add((200, 203), 202);
        tileDict_tr.Add((200, 204), 204);
        tileDict_tr.Add((200, 201), 202);
        tileDict_tr.Add((200, 210), 210);
        tileDict_tr.Add((200, 211), 211);
        tileDict_tr.Add((200, 205), 204);
        tileDict_tr.Add((200, 206), 211);
        tileDict_tr.Add((200, 208), 209);
        tileDict_tr.Add((200, 212), 200);
        tileDictList.Add(tileDict_tr);

        tileDict_r.Add((200, 100), 204);
        tileDict_r.Add((200, 200), 200);
        tileDict_r.Add((200, 203), 204);
        tileDict_r.Add((200, 202), 210);
        tileDict_r.Add((200, 205), 204);
        tileDict_r.Add((200, 212), 200);
        tileDict_r.Add((200, 206), 211);
        tileDict_r.Add((200, 209), 200);
        tileDict_r.Add((200, 211), 200);
        tileDictList.Add(tileDict_r);

        tileDict_br.Add((200, 100), 205);
        tileDict_br.Add((200, 206), 206);
        tileDict_br.Add((200, 204), 204);
        tileDict_br.Add((200, 210), 210);
        tileDict_br.Add((200, 200), 200);
        tileDict_br.Add((200, 203), 204);
        tileDict_br.Add((200, 207), 206);
        tileDict_br.Add((200, 212), 212);
        tileDict_br.Add((200, 211), 211);
        tileDict_br.Add((200, 209), 200);
        tileDict_br.Add((200, 202), 210);
        tileDictList.Add(tileDict_br);

        tileDict_b.Add((200, 100), 206);
        tileDict_b.Add((200, 205), 206);
        tileDict_b.Add((200, 207), 206);
        tileDict_b.Add((200, 200), 200);
        tileDict_b.Add((200, 210), 200);
        tileDict_b.Add((200, 204), 211);
        tileDict_b.Add((200, 208), 212);
        tileDict_b.Add((200, 203), 211);
        tileDict_b.Add((200, 209), 200);
        tileDict_b.Add((200, 202), 200);
        tileDictList.Add(tileDict_b);

        tileDict_bl.Add((200, 100), 207);
        tileDict_bl.Add((200, 206), 206);
        tileDict_bl.Add((200, 208), 208);
        tileDict_bl.Add((200, 200), 200);
        tileDict_bl.Add((200, 209), 209);
        tileDict_bl.Add((200, 201), 208);
        tileDict_bl.Add((200, 212), 212);
        tileDict_bl.Add((200, 210), 200);
        tileDict_bl.Add((200, 211), 211);
        tileDict_bl.Add((200, 205), 206);
        tileDict_bl.Add((200, 204), 211);
        tileDict_bl.Add((200, 202), 209);
        tileDictList.Add(tileDict_bl);

        tileDict_l.Add((200, 100), 208);
        tileDict_l.Add((200, 200), 200);
        tileDict_l.Add((200, 201), 208);
        tileDict_l.Add((200, 202), 209);
        tileDict_l.Add((200, 210), 200);
        tileDict_l.Add((200, 207), 208);
        tileDict_l.Add((200, 206), 212);
        tileDict_l.Add((200, 204), 200);
        tileDict_l.Add((200, 211), 200);
        tileDict_l.Add((200, 205), 212);
        tileDictList.Add(tileDict_l);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
