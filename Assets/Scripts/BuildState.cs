using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildState : GameBaseState
{
    public MetaData metaData;
    public SpriteRenderer sr;
    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        metaData.doneButton.gameObject.SetActive(true);

        metaData.g_grid = Grid.FindObjectOfType<Grid>();
        metaData.instantSR = metaData.instantObject.GetComponent<SpriteRenderer>();
        metaData.inspectScreen.SetActive(false);
    }



    public override void UpdateState(GameStateManager gameState)
    {
        //gets mouse pos
        metaData.mousePosition = Input.mousePosition;
        metaData.mousePosition = Camera.main.ScreenToWorldPoint(metaData.mousePosition);

        //moves game object to mouse then snaps to grid
        metaData.ghostImage.transform.position = Vector2.Lerp(metaData.ghostImage.transform.position, metaData.mousePosition, metaData.moveSpeed);
        Vector3Int cp = metaData.g_grid.LocalToCell(metaData.ghostImage.transform.localPosition);
        metaData.ghostImage.transform.localPosition = metaData.g_grid.GetCellCenterLocal(cp);

        //places building when left click
        if (Input.GetMouseButtonDown(0) && metaData.selectedType == "building" && metaData.canPlace)
        {
            metaData.instantSR.sprite = metaData.sr.sprite;
            GameObject clone = GameObject.Instantiate(metaData.instantObject, metaData.ghostImage.transform.position, metaData.ghostImage.transform.rotation);
            clone.GetComponent<InteractableBuilding_N>().sellPrice = metaData.cost;
            metaData.gold = metaData.gold - metaData.cost;
            metaData.goldCounter.text = metaData.gold.ToString() + " Gold";

            //ignore this, I usually just comment out obsolete code but I keep it just in case
            //instantCollider = clone.GetComponent<BoxCollider2D>();
            //instantCollider.size = buildingDimesions;
            //instantCollider.isTrigger = true;
        }

        if (Input.GetMouseButton(0) && metaData.selectedType == "tile")
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = metaData.map.WorldToCell(mousePos);

            metaData.map.SetTile(gridPos, metaData.selectedTile);

        }

    }

    private void placeTile(int tileid, Vector3Int gridPos)
    {

        if (metaData.gold < metaData.cost)
        {
            Debug.Log("you are broke.");
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

        int tl_id = metaData.tileDictList[0][(tileid, metaData.dataFromBase[metaData.map.GetTile(tl_pos)].id)];
        int t_id = metaData.tileDictList[1][(tileid, metaData.dataFromBase[metaData.map.GetTile(t_pos)].id)];
        int tr_id = metaData.tileDictList[2][(tileid, metaData.dataFromBase[metaData.map.GetTile(tr_pos)].id)];
        int r_id = metaData.tileDictList[3][(tileid, metaData.dataFromBase[metaData.map.GetTile(r_pos)].id)];
        int br_id = metaData.tileDictList[4][(tileid, metaData.dataFromBase[metaData.map.GetTile(br_pos)].id)];
        int b_id = metaData.tileDictList[5][(tileid, metaData.dataFromBase[metaData.map.GetTile(b_pos)].id)];
        int bl_id = metaData.tileDictList[6][(tileid, metaData.dataFromBase[metaData.map.GetTile(bl_pos)].id)];
        int l_id = metaData.tileDictList[7][(tileid, metaData.dataFromBase[metaData.map.GetTile(l_pos)].id)];

        metaData.map.SetTile(gridPos, getTileWithID(tileid));
        metaData.map.SetTile(tl_pos, getTileWithID(tl_id));
        metaData.map.SetTile(t_pos, getTileWithID(t_id));
        metaData.map.SetTile(tr_pos, getTileWithID(tr_id));
        metaData.map.SetTile(r_pos, getTileWithID(r_id));
        metaData.map.SetTile(br_pos, getTileWithID(br_id));
        metaData.map.SetTile(b_pos, getTileWithID(b_id));
        metaData.map.SetTile(bl_pos, getTileWithID(bl_id));
        metaData.map.SetTile(l_pos, getTileWithID(l_id));

        metaData.gold = metaData.gold - metaData.cost;
        metaData.goldCounter.text = metaData.gold.ToString() + " Gold";
    }

    public TileBase getTileWithID(int id)
    {
        foreach(TileData tiledata in metaData.tileDatas)
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
        foreach (BuildingData data in metaData.buildingDatas)
        {
            if (data.id == id)
            {
                return data;
            }
        }

        return null;
    }

    public void test()
    {
        Debug.Log("nle");
    }
}
