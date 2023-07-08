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
            if (!rayHit.collider) return;

            Debug.Log(rayHit.collider.gameObject);
            if(rayHit.collider.gameObject.GetComponent<InteractableBuilding_N>() != null)
            {
                metaData.inspectScreen.SetActive(true);
                metaData.selectedBuildingText.text = metaData.selectedName;
                metaData.selectedGO = rayHit.collider.gameObject;
                metaData.selectedBuildingImage.sprite = rayHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

}
