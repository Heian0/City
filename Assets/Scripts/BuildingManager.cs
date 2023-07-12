using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public MetaData metaData;
    public void PlaceBuilding()
    {
        metaData.instantSR.sprite = metaData.sr.sprite;
        GameObject clone = GameObject.Instantiate(metaData.instantObject, metaData.ghostImage.transform.position, metaData.ghostImage.transform.rotation);
        clone.GetComponent<InteractableBuilding_N>().sellPrice = -metaData.cost;
    }
    public void PlaceTile()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = metaData.map.WorldToCell(mousePos);

        metaData.map.SetTile(gridPos, metaData.selectedTile);
    }
}
