using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class ShopItem_N : MonoBehaviour
{
    [Header("Item Stats")]
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

    [SerializeField]
    public TileBase tile;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItem()
    {
        //set the metadata to the current item selected
        metaData.curItem = this;

        if (metaData.curItem.name == "Shovel")
        {
            metaData.buyButton.gameObject.SetActive(false);
            metaData.useButton.gameObject.SetActive(true);
            priceTxt.gameObject.SetActive(false);
            metaData.priceText.gameObject.SetActive(false);

            nameTxt.text = itemName.text;
            itemImage.sprite = itemArt.sprite;

            //sets the ghost image to the currently selected shop item
            ghostSprite.sprite = itemArt.sprite;
            ghostObject.SetActive(false);

            return;

        }

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

        //sets ghost image to the same hitbox size as the building to be placed so it can check for collisions
        ghostObject.GetComponent<BoxCollider2D>().size = new Vector2(width - 0.1f, height - 0.1f);
    }
}
