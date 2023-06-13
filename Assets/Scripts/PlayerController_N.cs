using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_N : MonoBehaviour
{
    private Vector3 cameraPosition;
    [SerializeField]
    private float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(cameraPosition.x) <= 13)
        {
            if (Input.GetKey(KeyCode.A))
            {
                cameraPosition.x -= cameraSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                cameraPosition.x += cameraSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                cameraPosition.y -= cameraSpeed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                cameraPosition.y += cameraSpeed;
            }
        }

        //this is for setting camera boundaries but we don't need that rn
        /*else if (cameraPosition.x > 13)
        {
            cameraPosition.x = 13;
        }
        else if (cameraPosition.x < -13)
        {
            cameraPosition.x = -13;
        }*/

        this.transform.position = cameraPosition;
    }
}
