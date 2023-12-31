using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Action<ItemSO, string> onItemSold;
    public static Action<ItemSO> onChangeEquipment;

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
    [SerializeField] private ItemSO currentEquipedHood;
    [SerializeField] private ItemSO currentEquipedBody;

    void Start()
    {
        buttonCloseInventory.onClick.AddListener(() => canvasGroupInventory.Hide());

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
        if (item != null)
        {
            if (item.type == ItemTypeEnum.Hood)
            {
                imageHood.sprite = item.imageItem;
                currentEquipedHood = item;
            }
            else
            {
                imageBody.sprite = item.imageItem;
                currentEquipedBody = item;
            }

            OnChangeEquipment(item);
        }
    }

    public void SellInventoryItem(ItemSO item)
    {
        if (Player.Instance.GetIsShopping())
        {
            ChangeItemAvailable(item.idItem);

            OnItemSold(item, "Item sold!");
            Player.Instance.AddCoins(item.price);
        }
    }

    private void ChangeItemAvailable(int idItem)
    {
        foreach (ButtonEquipmentPrefab item in contentEquipments.GetComponentsInChildren<ButtonEquipmentPrefab>())
        {
            if (item.GetItemId() == idItem)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private void OnItemSold(ItemSO item, string message)
    {
        if (onItemSold != null)
            onItemSold.Invoke(item, message);

        if (currentEquipedHood == item)
        {
            ChangeEquipedItem(startingItems.FirstOrDefault());
        }
        else if (currentEquipedBody == item)
        {
            ChangeEquipedItem(startingItems[1]);
        }
    }

    private void OnChangeEquipment(ItemSO item)
    {
        if (onChangeEquipment != null)
            onChangeEquipment.Invoke(item);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainScene")
        {
            canvasGroupInventory.Hide();
            ChangeEquipedItem(currentEquipedHood);
            ChangeEquipedItem(currentEquipedBody);
        }
    }

    void OnEnable()
    {
        Shop.onPurchaseItem += CreateItem;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Shop.onPurchaseItem -= CreateItem;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
