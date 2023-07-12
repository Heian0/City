using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostImage : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
    private Grid g_grid;
    [SerializeField]
    private bool canPlace;
    [SerializeField]
    private Color canNotPlaceColor;
    [SerializeField]
    private Color canPlaceColor;

    //public GameObject instantObject;
    public MetaData metaData;

    public SpriteRenderer sr;
    //public SpriteRenderer instantSR;
    public BoxCollider2D instantCollider;
    public Vector2 buildingDimesions;

    // Use this for initialization
    void Start()
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        g_grid = Grid.FindObjectOfType<Grid>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        //instantSR = instantObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets mouse pos
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //moves game object to mouse then snaps to grid
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, mousePosition, moveSpeed);
        Vector3Int cp = g_grid.LocalToCell(gameObject.transform.localPosition);
        gameObject.transform.localPosition = g_grid.GetCellCenterLocal(cp);
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        //detects if the building you're trying to place is being blocked then changes its colour to red
        sr.color = canNotPlaceColor;
        metaData.canPlace = false;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //detects if the building you're trying to place is not blocked and changes colour back to normal
        sr.color = canPlaceColor;
        metaData.canPlace = true;

    }
}
