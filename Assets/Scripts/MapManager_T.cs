using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager_T : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private Tilemap buildingMap;

    [SerializeField]
    private List<TileData> tileDatas;

    [SerializeField]
    private List<BuildingData> buildingDatas;

    public Dictionary<TileBase, TileData> dataFromBase = new Dictionary<TileBase, TileData>();

    public ShopManager_N shopManager;
    public int selectedID;
    public string selectedType;
    public int cost;

    private void Awake()
    {
        foreach (var tileData in tileDatas)
        {
            dataFromBase.Add(tileData.tile, tileData);
        }
    }

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

    private void Start()
    {
        //Gotta fix this dogshit system eventually
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = map.WorldToCell(mousePos);

            //200 should become id of selected tile in shop


            if (selectedType == "tile")
            {
                placeTile(selectedID, gridPos);
            }

            if (selectedType == "building")
            {
                placeBuilding(selectedID, gridPos);
            }   
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = buildingMap.WorldToCell(mousePos);

            placeBuilding(0, gridPos);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = buildingMap.WorldToCell(mousePos);

            placeBuilding(1, gridPos);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = buildingMap.WorldToCell(mousePos);

            placeBuilding(2, gridPos);
        }
    }

    private void placeTile(int tileid, Vector3Int gridPos)
    {

        if (shopManager.gold < cost)
        {
            print("you are broke.");
            return;
        }

        Vector3Int tl_pos = gridPos + new Vector3Int(-1, 1);
        Vector3Int t_pos = gridPos + new Vector3Int(0, 1);
        Vector3Int tr_pos = gridPos + new Vector3Int(1, 1);
        Vector3Int r_pos = gridPos + new Vector3Int(1, 0);
        Vector3Int br_pos = gridPos + new Vector3Int(1, -1);
        Vector3Int b_pos = gridPos + new Vector3Int(0, -1);
        Vector3Int bl_pos = gridPos + new Vector3Int(-1, -1);
        Vector3Int l_pos = gridPos + new Vector3Int(-1, 0);

        int tl_id = tileDictList[0][(tileid, dataFromBase[map.GetTile(tl_pos)].id)];
        int t_id = tileDictList[1][(tileid, dataFromBase[map.GetTile(t_pos)].id)];
        int tr_id = tileDictList[2][(tileid, dataFromBase[map.GetTile(tr_pos)].id)];
        int r_id = tileDictList[3][(tileid, dataFromBase[map.GetTile(r_pos)].id)];
        int br_id = tileDictList[4][(tileid, dataFromBase[map.GetTile(br_pos)].id)];
        int b_id = tileDictList[5][(tileid, dataFromBase[map.GetTile(b_pos)].id)];
        int bl_id = tileDictList[6][(tileid, dataFromBase[map.GetTile(bl_pos)].id)];
        int l_id = tileDictList[7][(tileid, dataFromBase[map.GetTile(l_pos)].id)];

        map.SetTile(gridPos, getTileWithID(tileid));
        map.SetTile(tl_pos, getTileWithID(tl_id));
        map.SetTile(t_pos, getTileWithID(t_id));
        map.SetTile(tr_pos, getTileWithID(tr_id));
        map.SetTile(r_pos, getTileWithID(r_id));
        map.SetTile(br_pos, getTileWithID(br_id));
        map.SetTile(b_pos, getTileWithID(b_id));
        map.SetTile(bl_pos, getTileWithID(bl_id));
        map.SetTile(l_pos, getTileWithID(l_id));

        shopManager.gold = shopManager.gold - cost;
    }

    private void placeBuilding(int buildingid, Vector3Int gridPos)
    {
        List<Vector3Int> vlist = new List<Vector3Int>();

        BuildingData bdata = getBuldingDataWithID(buildingid);

        if (shopManager.gold < cost)
        {
            print("you are broke.");
            return;
        }

        for (int i = 0; i < bdata.layout.Count; i++)
        {
            for(int j = 0; j < bdata.layout[i].list.Count; j++)
            {
                if (bdata.layout[i].list[j] == 1)
                {

                    Vector3Int pos = gridPos + new Vector3Int(j, -i);
                    print(map.GetTile(pos));
                    if (dataFromBase[map.GetTile(pos)].canPlaceBuilding == false || buildingMap.HasTile(pos))
                    {
                        return;
                    }
                    print(dataFromBase[map.GetTile(pos)].groundCode);
                    print(bdata.groundCode);
                    if (bdata.groundCode != 99 && dataFromBase[map.GetTile(pos)].groundCode != bdata.groundCode)
                    {
                        return;
                    }

                    vlist.Add(pos);
                }
            }
        }

        for (int i = 0; i < bdata.buildingTiles.Count; i++)
        {
            buildingMap.SetTile(vlist[i], bdata.buildingTiles[i]);
        }

        shopManager.gold = shopManager.gold - cost;
    }

    public TileBase getTileWithID(int id)
    {
        foreach(TileData tiledata in tileDatas)
        {
            if (tiledata.id == id)
            {
                return tiledata.tile;
            }
        }

        return null;
    }
    public BuildingData getBuldingDataWithID(int id)
    {
        foreach (BuildingData data in buildingDatas)
        {
            if (data.id == id)
            {
                return data;
            }
        }

        return null;
    }
}
