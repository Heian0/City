using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem_N : MonoBehaviour
{
    [Header("Item Stats")]
    [SerializeField]
    private int itemPrice;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Image itemArt;
    [Header("References")]
    public TMP_Text priceTxt;
    public TMP_Text nameTxt;
    public Image itemImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItem()
    {
        priceTxt.text = itemPrice.ToString() + " Gold";
        nameTxt.text = itemName;
        itemImage.sprite = itemArt.sprite;
    }
}
