using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NullState : GameBaseState
{
    public MetaData metaData;
    public override void EnterState(GameStateManager gameState)
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        //metaData.inspectScreen.SetActive(false);
    }

    // Update is called once per frame
    public override void UpdateState(GameStateManager gameState)
    {

    }

}
