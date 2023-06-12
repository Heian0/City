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
    private TMP_Text itemName;
    [SerializeField]
    private Image itemArt;
    [Header("References")]
    public TMP_Text priceTxt;
    public TMP_Text nameTxt;
    public Image itemImage;
    public int id;
    public string type;
    //public GameObject buyPanel;
    public ShopManager_N shopManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        priceTxt = GameObject.Find("Price").GetComponent<TMP_Text>();
        nameTxt = GameObject.Find("Item Name").GetComponent<TMP_Text>();
        itemImage = GameObject.Find("Image").GetComponent<Image>();
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager_N>();
    }

    void Awake()
    {
        //buyPanel = GameObject.Find("Item Stats");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItem()
    {
        //buyPanel.SetActive(true);
        shopManager.curItem = this;
        priceTxt.text = itemPrice.ToString() + " Gold";
        nameTxt.text = itemName.text;
        itemImage.sprite = itemArt.sprite;     
    }
}
