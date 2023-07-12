using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InspectState : GameBaseState
{
    public MetaData metaData;
    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        metaData.doneButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void UpdateState(GameStateManager gameState)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var rayHit = Physics2D.GetRayIntersection(metaData.cam.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider && rayHit.collider.gameObject.GetComponent<InteractableBuilding_N>() != null)
            {
                Debug.Log(rayHit.collider.gameObject);
                if (metaData.selectedGO != null)
                {
                    metaData.selectedGO.GetComponent<InteractableBuilding_N>().isSelected = false;
                }
                metaData.inspectScreen.SetActive(true);
                metaData.selectedBuildingText.text = metaData.selectedName;
                metaData.selectedGO = rayHit.collider.gameObject;
                metaData.selectedGO.GetComponent<InteractableBuilding_N>().isSelected = true;
                metaData.selectedBuildingImage.sprite = rayHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            }

            if (metaData.isShovelling)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var tpos = metaData.map.WorldToCell(worldPoint);

                // Try to get a tile from cell position
                var tile = metaData.map.GetTile(tpos);
                ;

                if (tile)
                {
                    metaData.inspectScreen.SetActive(true);
                    metaData.selectedBuildingText.text = metaData.selectedName;
                    metaData.selectedGO = rayHit.collider.gameObject;
                    metaData.selectedGO.GetComponent<InteractableBuilding_N>().isSelected = true;
                    metaData.selectedBuildingImage.sprite = rayHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
                }
            }
        }

    }

}
