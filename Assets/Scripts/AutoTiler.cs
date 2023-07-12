using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTiler : MonoBehaviour
{
    public MetaData metaData;

    public List<int> empty;
    public List<int> twoRight;
    public List<int> twoLeft;
    public List<int> twoUp;
    public List<int> twoDown;


    public List<TileData> tilesInGroup;

    public SpriteRenderer c;
    public SpriteRenderer tl;
    public SpriteRenderer t;
    public SpriteRenderer tr;
    public SpriteRenderer r;
    public SpriteRenderer br;
    public SpriteRenderer b;
    public SpriteRenderer bl;
    public SpriteRenderer l;

    public List<SpriteRenderer> allSrs;

    public int c_id;
    public int tl_id;
    public int t_id;
    public int tr_id;
    public int r_id;
    public int br_id;
    public int b_id;
    public int bl_id;
    public int l_id;

    public Vector3Int tl_pos;
    public Vector3Int t_pos;
    public Vector3Int tr_pos;
    public Vector3Int r_pos;
    public Vector3Int br_pos;
    public Vector3Int b_pos;
    public Vector3Int bl_pos;
    public Vector3Int l_pos;

    public Color cantPlaceColour;
    public Color canPlaceColour;
    private Grid g_grid;

    [SerializeField]
    public TileBase tile;

    // Start is called before the first frame update
    void Start()
    {
        metaData = GetComponent<MetaData>();
        g_grid = Grid.FindObjectOfType<Grid>();
        metaData.inspectScreen.SetActive(false);
        tilesInGroup = getTilesInGroup(metaData.selectedTileGroupCode);
        tilesInGroup.OrderBy(a => a.tileTypeId);



        allSrs.Add(c);
        allSrs.Add(tl);
        allSrs.Add(t);
        allSrs.Add(tr);
        allSrs.Add(r);
        allSrs.Add(br);
        allSrs.Add(b);
        allSrs.Add(bl);
        allSrs.Add(l);
    }

    // Update is called once per frame
    void Update()
    {
        /*

        //gets mouse pos
        metaData.mousePosition = Input.mousePosition;
        metaData.mousePosition = Camera.main.ScreenToWorldPoint(metaData.mousePosition);

        //moves game object to mouse then snaps to grid
        metaData.tileGhostImage.transform.position = Vector2.Lerp(metaData.tileGhostImage.transform.position, metaData.mousePosition, metaData.moveSpeed);
        Vector3Int cp = metaData.g_grid.LocalToCell(metaData.tileGhostImage.transform.localPosition);
        metaData.tileGhostImage.transform.localPosition = metaData.g_grid.GetCellCenterLocal(cp) + new Vector3(-0.5f, 0.5f, 0);
        */

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = metaData.map.WorldToCell(mousePos);
        //print(gridPos);

        /*
        tl_pos = gridPos + new Vector3Int(-1, 1);
        t_pos = gridPos + new Vector3Int(0, 1);
        tr_pos = gridPos + new Vector3Int(1, 1);
        r_pos = gridPos + new Vector3Int(1, 0);
        br_pos = gridPos + new Vector3Int(1, -1);
        b_pos = gridPos + new Vector3Int(0, -1);
        bl_pos = gridPos + new Vector3Int(-1, -1);
        l_pos = gridPos + new Vector3Int(-1, 0);

        List<int> listy = getTileBitmask(3, gridPos);

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (int i in listy)
            {
                print(i);
            }

        }



        if (listy.SequenceEqual(empty))
        {
            //changeGhostImageColour(canPlaceColour);

            c.sprite = tilesInGroup[0].sprite;
            c_id = 0;

            tl.sprite = tilesInGroup[1].sprite;
            tl_id = 1;

            t.sprite = tilesInGroup[2].sprite;
            t_id = 2;

            tr.sprite = tilesInGroup[3].sprite;
            tr_id = 3;

            r.sprite = tilesInGroup[4].sprite;
            r_id = 4;

            br.sprite = tilesInGroup[5].sprite;
            br_id = 5;

            b.sprite = tilesInGroup[6].sprite;
            b_id = 6;

            bl.sprite = tilesInGroup[7].sprite;
            bl_id = 7;

            l.sprite = tilesInGroup[8].sprite;
            l_id = 8;
        }

        if (listy.SequenceEqual(twoRight))
        {
            //changeGhostImageColour(canPlaceColour);
            c.sprite = tilesInGroup[0].sprite;
            c_id = 0;

            tl.sprite = tilesInGroup[2].sprite;
            tl_id = 2;

            t.sprite = tilesInGroup[2].sprite;
            t_id = 2;

            tr.sprite = tilesInGroup[3].sprite;
            tr_id = 3;

            r.sprite = tilesInGroup[4].sprite;
            r_id = 4;

            br.sprite = tilesInGroup[5].sprite;
            br_id = 5;

            b.sprite = tilesInGroup[6].sprite;
            b_id = 6;

            bl.sprite = tilesInGroup[6].sprite;
            bl_id = 6;

            l.sprite = tilesInGroup[0].sprite;
            l_id = 0;
        }

        if (listy.SequenceEqual(twoLeft))
        {
            //changeGhostImageColour(canPlaceColour);

            c.sprite = tilesInGroup[0].sprite;
            tl.sprite = tilesInGroup[1].sprite;
            t.sprite = tilesInGroup[2].sprite;
            tr.sprite = tilesInGroup[3].sprite;
            r.sprite = tilesInGroup[4].sprite;
            br.sprite = tilesInGroup[5].sprite;
            b.sprite = tilesInGroup[6].sprite;
            bl.sprite = tilesInGroup[7].sprite;
            l.sprite = tilesInGroup[8].sprite;
        }

        else
        {
            //changeGhostImageColour(cantPlaceColour);

            c.sprite = tilesInGroup[0].sprite;
            c_id = 0;

            tl.sprite = tilesInGroup[1].sprite;
            tl_id = 1;

            t.sprite = tilesInGroup[2].sprite;
            t_id = 2;

            tr.sprite = tilesInGroup[3].sprite;
            tr_id = 3;

            r.sprite = tilesInGroup[4].sprite;
            r_id = 4;

            br.sprite = tilesInGroup[5].sprite;
            br_id = 5;

            b.sprite = tilesInGroup[6].sprite;
            b_id = 6;

            bl.sprite = tilesInGroup[7].sprite;
            bl_id = 7;

            l.sprite = tilesInGroup[8].sprite;
            l_id = 8;
        }
                        */

        if (Input.GetKey(KeyCode.T))
        {       
            //metaData.map.SetTile(gridPos, tilesInGroup[c_id].tile);
            //metaData.map.SetTile(tl_pos, tilesInGroup[tl_id].tile);
            //metaData.map.SetTile(t_pos, tilesInGroup[t_id].tile);
            //metaData.map.SetTile(tr_pos, tilesInGroup[tr_id].tile);
            //metaData.map.SetTile(r_pos, tilesInGroup[r_id].tile);
            //metaData.map.SetTile(br_pos, tilesInGroup[br_id].tile);
            //metaData.map.SetTile(b_pos, tilesInGroup[b_id].tile);
            //metaData.map.SetTile(bl_pos, tilesInGroup[bl_id].tile);
            //metaData.map.SetTile(l_pos, tilesInGroup[l_id].tile);

            metaData.map.SetTile(gridPos, tile);
            print("p");
        }


    }


    public TileBase getTileWithID(int id)
    {
        foreach (TileData tiledata in metaData.tileDatas)
        {
            if (tiledata.id == id)
            {
                return tiledata.tile;
            }
        }

        return null;
    }

    //grab tileSet from TileData with tileGroupId
    public List<int> getTileBitmask(int tileGroupId, Vector3Int gridPos)
    {


        List<int> bitMask = new List<int> {
                                            getTileTypeId(gridPos),
                                            getTileTypeId(tl_pos),
                                            getTileTypeId(t_pos),
                                            getTileTypeId(tr_pos),
                                            getTileTypeId(r_pos),
                                            getTileTypeId(br_pos),
                                            getTileTypeId(b_pos),
                                            getTileTypeId(bl_pos),
                                            getTileTypeId(l_pos),

                                           };


        return bitMask;
    }

    public List<TileData> getTilesInGroup(int tileGroupId)
    {
        List<TileData> listy = new List<TileData>();
        foreach (TileData td in metaData.tileDatas)
        {
            if (td.tileGroupId == tileGroupId)
            {
                listy.Add(td);
            }
        }

        return listy;
    }

    public int getTileTypeId(Vector3Int pos)
    {
        if (metaData.map.GetTile(pos) == null)
        {
            return 99;
        }

        return metaData.dataFromBase[metaData.map.GetTile(pos)].tileTypeId;
    }

    public void changeGhostImageColour(Color colour)
    {
        foreach (SpriteRenderer sr in allSrs)
        {
            sr.color = colour;
        }
    }
}
