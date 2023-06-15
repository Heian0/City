using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuyState : GameBaseState
{
    public MetaData metaData;
    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
    }

    // Update is called once per frame
    public override void UpdateState(GameStateManager gameState)
    {
        
    }

}
