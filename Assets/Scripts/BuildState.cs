using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildState : GameBaseState
{
    public MetaData metaData;
    public GoldManager goldManager;
    public BuildingManager buildingManager;

    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        goldManager = GameObject.Find("Manager").GetComponent<GoldManager>();
        buildingManager = GameObject.Find("Manager").GetComponent<BuildingManager>();

        metaData.doneButton.gameObject.SetActive(true);
        metaData.inspectScreen.SetActive(false);
    }



    public override void UpdateState(GameStateManager gameState)
    {
        //places building when left click
        if (Input.GetMouseButtonDown(0) && metaData.selectedType == "building" && metaData.canPlace)
        {
            buildingManager.PlaceBuilding();
            goldManager.EditGold(metaData.curItem.itemPrice);
        }

        //places tile when left click
        if (Input.GetMouseButton(0) && metaData.selectedType == "tile")
        {
            buildingManager.PlaceTile();
        }
    }
}
