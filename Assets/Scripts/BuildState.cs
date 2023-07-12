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

        metaData.g_grid = Grid.FindObjectOfType<Grid>();
        metaData.instantSR = metaData.instantObject.GetComponent<SpriteRenderer>();

        metaData.doneButton.gameObject.SetActive(true);
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
