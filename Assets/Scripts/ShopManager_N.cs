using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopManager_N : MonoBehaviour
{
    public int gold;
    public TMP_Text goldCounter;
    public MapManager_T mapManager;
    public ShopItem_N curItem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldCounter.text = gold.ToString() + " Gold";
    }

    public void OnBuyItem()
    {

        mapManager.selectedID = curItem.id;
        mapManager.selectedType = curItem.type;
        mapManager.cost = curItem.itemPrice;
    }
}
