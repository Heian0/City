using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currState;

    //gamestates
    public BuildState buildState = new BuildState();
    public BuyState buyState = new BuyState();
    public InspectState inspectState = new InspectState();
    public NullState nullState = new NullState();

    public MetaData metaData;

    public GameObject ghostObject;
    public SpriteRenderer ghostSprite;
    public GameObject shopButton;

    private bool beingHandled = false;

    void Start()
    {
        //starting state 
        currState = inspectState;

        //"this" is a refernece to the context (this exact MonoBehaviour script)
        currState.EnterState(this);
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();

        //finds the "Ghost Image" object and its sprite renderer
        ghostSprite = ghostObject.GetComponent<SpriteRenderer>();
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

    public void OnRemoveClick()
    {
        GameObject.Destroy(metaData.selectedGO);
        metaData.inspectScreen.SetActive(false);
        metaData.gold += metaData.selectedGO.GetComponent<InteractableBuilding_N>().sellPrice;
        metaData.goldCounter.text = metaData.gold.ToString() + " Gold";
    }

    //game state for when cursor is hovered over shop button to prevent building placing
    /*public void OnShopHover()
    {
        ghostObject.SetActive(false);
        currState = nullState;
        nullState.EnterState(this);
        print(currState);
    }*/

    //game state for when shop button is clicked
    public void OnShopClick()
    {
        metaData.selectedGO.GetComponent<InteractableBuilding_N>().isSelected = false;
        metaData.inspectScreen.SetActive(false);
        ghostObject.SetActive(true);
        ghostSprite.sprite = null;
        currState = buyState;
        buyState.EnterState(this);
        print(currState);
    }

    public void OnShopExit()
    {
        ghostObject.SetActive(true);
        ghostSprite.sprite = null;
        currState = inspectState;
        inspectState.EnterState(this);
        print(currState);
    }

    //game state for when buy button is clicked in shop
    /*public void OnShopExitHover()
    {

        if (currState == nullState)
        {
            ghostObject.SetActive(true);
            currState = buildState;
            buildState.EnterState(this);
            print(currState);
        }
    }*/

    public void OnDoneHover()
    {
        ghostObject.SetActive(false);
        currState = nullState;
        nullState.EnterState(this);
        print(currState);
    }

    //game state for when done button is clicked
    public void OnDoneClick()
    {
        metaData.isTiling = false;
        shopButton.SetActive(true);
        ghostObject.SetActive(true);
        ghostSprite.sprite = null;
        currState = inspectState;
        inspectState.EnterState(this);
        print(currState);
    }

    public void OnDoneExitHover()
    {
        if (currState == nullState)
        {
            ghostObject.SetActive(true);
            currState = buildState;
            buildState.EnterState(this);
            print(currState);
        }
    }

    public void OnInspectScreenExit()
    {
        metaData.selectedGO.GetComponent<InteractableBuilding_N>().isSelected = false;
        metaData.inspectScreen.SetActive(false);
    }

    //game state for when buy button is clicked in shop
    public void OnBuyClick()
    {
        shopButton.SetActive(false);
        currState = buildState;
        buildState.EnterState(this);
        print(currState);

        //sets metadata to the shop item selected
        metaData.selectedID = metaData.curItem.id;
        metaData.selectedType = metaData.curItem.type;
        metaData.cost = metaData.curItem.itemPrice;
        metaData.selectedName = metaData.curItem.name;

        if (metaData.selectedType == "tile")
        {
            metaData.isTiling = true;
        }

        //shows a "ghost image" of the shop item you are going to place
        ghostObject.SetActive(true);
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
