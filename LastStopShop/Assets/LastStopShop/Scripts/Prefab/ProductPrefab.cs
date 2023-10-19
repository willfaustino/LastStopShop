using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductPrefab : MonoBehaviour
{
    [SerializeField] private Button buttonBuy;
    [SerializeField] private Image imageProduct;
    [SerializeField] private TextMeshProUGUI textProductName;
    [SerializeField] private TextMeshProUGUI textProductPrice;

    private ItemSO _item;

    public void SetUI(ItemSO item, UnityAction purchaseAction)
    {
        _item = item;
        imageProduct.sprite = item.imageItem;
        textProductName.text = item.nameItem;
        textProductPrice.text = "$ " + item.price.ToString();

        buttonBuy.onClick.AddListener(purchaseAction);
    }

    public int GetProductId()
    {
        return _item.idItem;
    }
}
