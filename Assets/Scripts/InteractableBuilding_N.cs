using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBuilding_N : MonoBehaviour
{
    [Header("Components")]
    public Sprite sprite;
    public SpriteRenderer sr;

    [Header("Building Stats")]
    //public string name;
    public int sellPrice;

    [Header("Blinking colours")]
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    public Color tilingColor;
    public bool isSelected;

    public float blinkSpeed;

    public MetaData metaData;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
    }

    // Update is called once per frame
    void Update()
    {
        //building starts blinking if selected
        if (isSelected)
        {
            StartCoroutine(Blinking());
        }
        //building turns transparent to allow for better vision while tiling
        else if (metaData.isTiling)
        {
            StopAllCoroutines();
            sr.color = tilingColor;
        }
        else
        {
            StopAllCoroutines();
            sr.color = startColor;
        }
    }

    IEnumerator Blinking() 
    {
        yield return null;
        sr.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * blinkSpeed, 1));
    }
}
