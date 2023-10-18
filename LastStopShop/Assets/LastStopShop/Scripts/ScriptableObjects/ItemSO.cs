using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/New Item")]
public class ItemSO : ScriptableObject
{
    public int idItem;
    public ItemTypeEnum type;
    public Sprite imageItem;
    public string nameItem;
    public int price;
    public List<Sprite> spritesEquipment;
}