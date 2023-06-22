using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildState : GameBaseState
{
    public MetaData metaData;
    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
    }

    public override void UpdateState(GameStateManager gameState)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = metaData.map.WorldToCell(mousePos);

            //200 should become id of selected tile in shop

            if (metaData.selectedType == "tile")
            {
                placeTile(metaData.selectedID, gridPos);
            }

            if (metaData.selectedType == "building")
            {
                //we need to change this into just instatiating a prefab for the building - Nicholas
                //placeBuilding(metaData.selectedID, gridPos);

                //instantiating a prefab of an interactable building at the mouse cursor
                //Instantiate(metaData.instantObject, mousePos, );
            }   
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = metaData.buildingMap.WorldToCell(mousePos);

            placeBuilding(0, gridPos);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = metaData.buildingMap.WorldToCell(mousePos);

            placeBuilding(1, gridPos);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = metaData.buildingMap.WorldToCell(mousePos);

            placeBuilding(2, gridPos);
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

    private void placeBuilding(int buildingid, Vector3Int gridPos)
    {
        List<Vector3Int> vlist = new List<Vector3Int>();

        BuildingData bdata = getBuldingDataWithID(buildingid);

        if (metaData.gold < metaData.cost)
        {
            Debug.Log("you are broke.");
            return;
        }

        for (int i = 0; i < bdata.layout.Count; i++)
        {
            for(int j = 0; j < bdata.layout[i].list.Count; j++)
            {
                if (bdata.layout[i].list[j] == 1)
                {

                    Vector3Int pos = gridPos + new Vector3Int(j, -i);
 
                    if (metaData.dataFromBase[metaData.map.GetTile(pos)].canPlaceBuilding == false || metaData.buildingMap.HasTile(pos))
                    {
                        return;
                    }

                    if (bdata.groundCode != 99 && metaData.dataFromBase[metaData.map.GetTile(pos)].groundCode != bdata.groundCode)
                    {
                        return;
                    }

                    vlist.Add(pos);
                }
            }
        }

        for (int i = 0; i < bdata.buildingTiles.Count; i++)
        {
            metaData.buildingMap.SetTile(vlist[i], bdata.buildingTiles[i]);
        }

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
