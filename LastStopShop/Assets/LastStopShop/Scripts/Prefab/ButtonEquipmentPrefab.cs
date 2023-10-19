using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonEquipmentPrefab : MonoBehaviour
{
    [SerializeField] private Button buttonEquipment;
    [SerializeField] private Image imageEquipment;
    [SerializeField] private Button buttonSellEquipment;

    private ItemSO _item;

    public void SetUI(ItemSO item, UnityAction equipAction, UnityAction sellAction)
    {
        _item = item;
        imageEquipment.sprite = item.imageItem;

        buttonEquipment.onClick.AddListener(equipAction);

        if (item.canBeSold)
            buttonSellEquipment.onClick.AddListener(sellAction);
        else
            buttonSellEquipment.gameObject.SetActive(false);
    }

    public int GetItemId()
    {
        return _item.idItem;
    }
}
