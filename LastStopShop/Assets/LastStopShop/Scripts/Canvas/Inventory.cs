using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Action<ItemSO> onItemSold;

    [Header("CanvasInventory")]
    [SerializeField] private CanvasGroup canvasGroupInventory;
    [SerializeField] private Button buttonCloseInventory;
    [SerializeField] private Image imageHood;
    [SerializeField] private Image imageBody;

    [Header("Inventory")]
    [SerializeField] private GameObject contentEquipments;
    [SerializeField] private ButtonEquipmentPrefab buttonEquipmentPrefab;

    [Header("Scriptable Objects")]
    [SerializeField] private List<ItemSO> startingItems;

    private List<ItemSO> currentEquipments;

    void Start()
    {
        buttonCloseInventory.onClick.AddListener(ChangeInventoryVisibility);
        //currentEquipments = new List<ItemSO>();
        //currentEquipments = startingItems;
        CreateEquipmentsList();
    }

    private void CreateEquipmentsList()
    {
        foreach (ItemSO item in startingItems)
        {
            CreateItem(item);
        }
    }

    private void CreateItem(ItemSO item)
    {
        ButtonEquipmentPrefab button;
        button = Instantiate(buttonEquipmentPrefab, transform);
        button.transform.SetParent(contentEquipments.transform);
        button.SetUI(item, () => ChangeEquipedItem(item), () => SellInventoryItem(item));
    }

    public void ChangeEquipedItem(ItemSO item)
    {
        print("change item");
    }

    public void SellInventoryItem(ItemSO item)
    {
        ChangeItemAvailable(item.idItem);
        OnItemSold(item);
        Player.Instance.AddCoins(item.price);
    }

    private void ChangeItemAvailable(int idItem)
    {
        foreach (ButtonEquipmentPrefab item in contentEquipments.GetComponentsInChildren<ButtonEquipmentPrefab>(true))
        {
            if (item.GetItemId() == idItem)
            {
                Destroy(item.gameObject);
            }
        }
    }

    void ChangeInventoryVisibility()
    {
        if (canvasGroupInventory.alpha == 1f)
        {
            canvasGroupInventory.Hide();
        }
        else
        {
            canvasGroupInventory.Show();
        }
    }

    private void OnItemSold(ItemSO item)
    {
        if (onItemSold != null)
            onItemSold.Invoke(item);
    }

    void OnEnable()
    {
        Shop.onPurchaseItem += CreateItem;
    }

    void OnDisable()
    {
        Shop.onPurchaseItem -= CreateItem;
    }

}
