using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currState;

    public BuildState buildState = new BuildState();
    public BuyState buyState = new BuyState();
    public MetaData metaData;

    private bool beingHandled = false;

    void Start()
    {
        //starting state 
        currState = buildState;
        //"this" is a refernece to the context (this exact MonoBehaviour script)
        currState.EnterState(this);
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
    }

    void Update()
    {
        currState.UpdateState(this);
    }

    public void SwitchState(GameBaseState gameState)
    {
        currState = gameState;
        gameState.EnterState(this);
    }
    public void OnShopClick()
    {
        currState = buyState;
        buyState.EnterState(this);
        print(currState);
    }

    public void OnBuyClick()
    {
        currState = buildState;
        buildState.EnterState(this);
        print(currState);

        metaData.selectedID = metaData.curItem.id;
        metaData.selectedType = metaData.curItem.type;
        metaData.cost = metaData.curItem.itemPrice;

    }

    public IEnumerator SwitchStateDelay(GameBaseState gameState, float time)
    {
        beingHandled = true;

        yield return new WaitForSeconds(time);

        currState = gameState;
        gameState.EnterState(this);

        beingHandled = false;
    }
}
