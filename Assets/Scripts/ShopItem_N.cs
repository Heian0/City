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
    public int width;
    public int height;
    public Image itemImage;
    public int id;
    public string type;
    public SpriteRenderer ghostSprite;
    public GameObject ghostObject;
    public SpriteRenderer instantSprite;
    public BoxCollider2D instantCollider;
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
        ghostSprite = GameObject.Find("Ghost Image").GetComponent<SpriteRenderer>();
        ghostObject = GameObject.Find("Ghost Image");
        instantSprite = GameObject.Find("Interactable Building").GetComponent<SpriteRenderer>();
        instantCollider = GameObject.Find("Interactable Building").GetComponent<BoxCollider2D>();
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
        //set the metadata to the current item selected
        metaData.curItem = this;

        //changes item stats in buy panel to the currently selected shop item
        priceTxt.text = itemPrice.ToString() + " Gold";
        nameTxt.text = itemName.text;
        itemImage.sprite = itemArt.sprite;

        //sets the ghost image to the currently selected shop item
        ghostSprite.sprite = itemArt.sprite;
        ghostObject.SetActive(false);

        //sets the sprite of the object to be instantiated
        instantSprite.sprite = itemArt.sprite;
        instantCollider.size = new Vector2(width, height);
        //ghostObject.GetComponent<GhostImage>().buildingDimesions = new Vector2(width, height);
        ghostObject.GetComponent<BoxCollider2D>().size = new Vector2(width - 0.1f, height - 0.1f);
    }
}
