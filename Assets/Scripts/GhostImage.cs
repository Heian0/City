using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostImage : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
    private Grid g_grid;

    public GameObject instantObject;
    public MetaData metaData;

    public SpriteRenderer sr;
    public SpriteRenderer instantSR;

    // Use this for initialization
    void Start()
    {
        g_grid = Grid.FindObjectOfType<Grid>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        instantSR = instantObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets mouse pos
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //moves game object to mouse then snaps to grid
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        Vector3Int cp = g_grid.LocalToCell(transform.localPosition);
        transform.localPosition = g_grid.GetCellCenterLocal(cp);

        //places building when left click
        if(Input.GetMouseButtonDown(0) && metaData.selectedType == "building")
        {
            instantSR.sprite = sr.sprite;
            Instantiate(instantObject, transform.position,transform.rotation);
        }
    }
}
