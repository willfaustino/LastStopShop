using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region "Instance"

    private static Shop _instance;

    public static Shop Instance
    {
        get { return _instance; }
        set
        {
            if (_instance == null)
            {
                _instance = value;
                DontDestroyOnLoad(_instance.gameObject);
            }
        }
    }

    protected virtual void Awake()
    {
        transform.SetParent(null);
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    #endregion

    public static Action<ItemSO> onPurchaseItem;

    [Header("CanvasShop")]
    public CanvasGroup canvasGroupShop;
    [SerializeField] private Button buttonCloseShop;
    [SerializeField] private TextMeshProUGUI textPurchaseMessage;

    [Header("Products")]
    [SerializeField] private GameObject contentProducts;
    [SerializeField] private ProductPrefab productPrefab;

    [Header("Scriptable Objects")]
    [SerializeField] private List<ItemSO> items;

    void Start()
    {
        buttonCloseShop.onClick.AddListener(CloseShop);
        CreateProductsList();
    }

    private void CreateProductsList()
    {
        foreach (ItemSO product in items)
        {
            CreateProduct(product);
        }
    }

    private void CreateProduct(ItemSO item, string message = "")
    {
        ProductPrefab button;
        button = Instantiate(productPrefab, transform);
        button.transform.SetParent(contentProducts.transform);
        button.SetUI(item, () => BuyItem(item));

        textPurchaseMessage.text = message;
    }

    private void BuyItem(ItemSO item)
    {
        if(Player.Instance.GetCoins() >= item.price)
        {
            Player.Instance.RemoveCoins(item.price);
            ChangeProductAvailable(item.idItem);
            OnPurchaseItem(item);
            textPurchaseMessage.text = "Item purchased successfully!";
        }
        else
        {
            textPurchaseMessage.text = "Not enough coins!";
        }
    }

    private void ChangeProductAvailable(int idProduct)
    {
        foreach (ProductPrefab product in contentProducts.GetComponentsInChildren<ProductPrefab>())
        {
            if (product.GetProductId() == idProduct)
            {
                Destroy(product.gameObject);
            }
        }
    }

    void CloseShop() 
    {
        textPurchaseMessage.text = "";
        canvasGroupShop.Hide();
        Player.Instance.SetIsShopping(false);
    }

    private void OnPurchaseItem(ItemSO item) 
    {
        if (onPurchaseItem != null)
            onPurchaseItem.Invoke(item);
    }

    void OnEnable()
    {
        Inventory.onItemSold += CreateProduct;
    }

    void OnDisable()
    {
        Inventory.onItemSold -= CreateProduct;
    }

}