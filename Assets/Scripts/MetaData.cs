using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class MetaData : MonoBehaviour
{
    [Header("Tilemap stuff")]
    public bool isTiling;

    [SerializeField]
    public Tilemap map;

    [SerializeField]
    public Tilemap baseMap;

    [SerializeField]
    public List<TileData> tileDatas;

    [SerializeField]
    public List<BuildingData> buildingDatas;

    public Dictionary<TileBase, TileData> dataFromBase = new Dictionary<TileBase, TileData>();

    [Header("Shop Stuff")]
    public int gold;
    public TMP_Text goldCounter;
    public int cost;
    public ShopItem_N curItem;

    [Header("Selected Building Stuff")]
    public int selectedID;
    public string selectedName;
    public string selectedType;
    public Camera cam;
    public TMP_Text selectedBuildingText;
    public GameObject selectedGO;
    public Image selectedBuildingImage;

    public TileBase selectedTile;

    [Header("Ghost Image Stuff")]
    [SerializeField]
    public GameObject ghostImage;
    public GameObject tileGhostImage;
    [SerializeField]
    public bool canPlace;

    [Header("Stuff for object to be instantiated")]
    public GameObject instantObject;
    public SpriteRenderer sr;
    public SpriteRenderer instantSR;
    public BoxCollider2D instantCollider;
    public Vector2 buildingDimesions;

    [Header("Miscellaneous")]
    public MetaData metaData;
    public int selectedTileGroupCode;
    public GameObject inspectScreen;
    public Button doneButton;
    public Button useButton;
    public Button buyButton;
    public TMP_Text priceText;
    public bool isShovelling = false;

    void Start()
    {
        foreach (var tileData in tileDatas)
        {
            dataFromBase.Add(tileData.tile, tileData);
        }
    }

}
