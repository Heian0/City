using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript_N : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
    private Grid g_grid;

    // Use this for initialization
    void Start()
    {
        g_grid = Grid.FindObjectOfType<Grid>();
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
    }
}
