using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currState;

    //gamestates
    public BuildState buildState = new BuildState();
    public BuyState buyState = new BuyState();
    public NullState nullState = new NullState();

    public MetaData metaData;

    public GameObject ghostObject;
    public SpriteRenderer ghostSprite;

    private bool beingHandled = false;

    void Start()
    {
        //starting state 
        currState = buildState;

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

    //
    public void OnShopHover()
    {
        ghostObject.SetActive(false);
        currState = nullState;
        nullState.EnterState(this);
        print(currState);
    }
    public void OnShopClick()
    {
        ghostObject.SetActive(true);
        ghostSprite.sprite = null;
        currState = buyState;
        buyState.EnterState(this);
        print(currState);
    }

    public void OnShopExitHover()
    {
        if (currState == nullState)
        {
            ghostObject.SetActive(true);
            currState = buildState;
            buildState.EnterState(this);
            print(currState);
        }
    }

    public void OnBuyClick()
    {
        currState = buildState;
        buildState.EnterState(this);
        print(currState);

        metaData.selectedID = metaData.curItem.id;
        metaData.selectedType = metaData.curItem.type;
        metaData.cost = metaData.curItem.itemPrice;


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
