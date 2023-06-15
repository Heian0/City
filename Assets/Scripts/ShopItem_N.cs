using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem_N : MonoBehaviour
{
    [Header("Item Stats")]
    [SerializeField]
    public int itemPrice;
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
    public BuyState buyState;
    public MetaData metaData;

    // Start is called before the first frame update
    void Start()
    {
        metaData = GameObject.Find("MapManager").GetComponent<MetaData>();
        priceTxt = GameObject.Find("Price").GetComponent<TMP_Text>();
        nameTxt = GameObject.Find("Item Name").GetComponent<TMP_Text>();
        itemImage = GameObject.Find("Image").GetComponent<Image>();
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
        metaData.curItem = this;
        priceTxt.text = itemPrice.ToString() + " Gold";
        nameTxt.text = itemName.text;
        itemImage.sprite = itemArt.sprite;     
    }
}
