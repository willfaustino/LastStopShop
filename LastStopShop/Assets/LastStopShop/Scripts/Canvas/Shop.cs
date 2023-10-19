using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Action<ItemSO> onPurchaseItem;

    [Header("CanvasShop")]
    [SerializeField] private CanvasGroup canvasGroupShop;
    [SerializeField] private Button buttonCloseShop;
    [SerializeField] private TextMeshProUGUI textPurchaseMessage;

    [Header("Products")]
    [SerializeField] private GameObject contentProducts;
    [SerializeField] private ProductPrefab productPrefab;

    [Header("Scriptable Objects")]
    [SerializeField] private List<ItemSO> items;

    void Start()
    {
        buttonCloseShop.onClick.AddListener(() => canvasGroupShop.Hide());
        CreateProductsList();
    }

    private void CreateProductsList()
    {
        foreach (ItemSO product in items)
        {
            CreateProduct(product);
        }
    }

    private void CreateProduct(ItemSO item)
    {
        ProductPrefab button;
        button = Instantiate(productPrefab, transform);
        button.transform.SetParent(contentProducts.transform);
        button.SetUI(item, () => BuyItem(item));
    }

    private void BuyItem(ItemSO item)
    {
        if(Player.Instance.GetCoins() >= item.price)
        {
            Player.Instance.RemoveCoins(item.price);
            // atualizar qtd moedas no text no canvasplayes
            textPurchaseMessage.text = "Item purchased successfully!";
        }
        else
        {
            textPurchaseMessage.text = "Not enough coins!";
        }

        ChangeProductAvailable(item.idItem);
        OnPurchaseItem(item);
    }

    private void ChangeProductAvailable(int idProduct)
    {
        foreach (ProductPrefab product in contentProducts.GetComponentsInChildren<ProductPrefab>(true))
        {
            if (product.GetProductId() == idProduct)
            {
                Destroy(product.gameObject);
            }
        }
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