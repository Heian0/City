using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager_T : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    public Dictionary<TileBase, TileData> dataFromBase = new Dictionary<TileBase, TileData>();

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
        tileDict_tl.Add((200, 100), 201);
        tileDict_tl.Add((200, 203), 202);
        tileDictList.Add(tileDict_tl);

        tileDict_t.Add((200, 100), 202);
        tileDictList.Add(tileDict_t);

        tileDict_tr.Add((200, 100), 203);
        tileDictList.Add(tileDict_tr);

        tileDict_r.Add((200, 100), 204);
        tileDictList.Add(tileDict_r);

        tileDict_br.Add((200, 100), 205);
        tileDictList.Add(tileDict_br);

        tileDict_b.Add((200, 100), 206);
        tileDictList.Add(tileDict_b);

        tileDict_bl.Add((200, 100), 207);
        tileDict_bl.Add((200, 205), 206);
        tileDictList.Add(tileDict_bl);

        tileDict_l.Add((200, 100), 208);
        tileDict_l.Add((200, 200), 200);
        tileDictList.Add(tileDict_l);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = map.WorldToCell(mousePos);

            //200 should become id of selected tile in shop
            placeTile(200, gridPos);
        }
    }

    private void placeTile(int tileid, Vector3Int gridPos)
    {
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
}
