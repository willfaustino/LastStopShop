using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private int _coins = 100;
    private int _currentItemId;

    public TextMeshProUGUI textCoins;

    [Header("PlayerSpriteRenderer")]
    [SerializeField] private SpriteRenderer spriteRendererHood;
    [SerializeField] private SpriteRenderer spriteRendererWristLeft;
    [SerializeField] private SpriteRenderer spriteRendererElbowLeft;
    [SerializeField] private SpriteRenderer spriteRendererShoulderLeft;
    [SerializeField] private SpriteRenderer spriteRendererWristRight;
    [SerializeField] private SpriteRenderer spriteRendererElbowRight;
    [SerializeField] private SpriteRenderer spriteRendererShoulderRight;
    [SerializeField] private SpriteRenderer spriteRendererTorso;
    [SerializeField] private SpriteRenderer spriteRendererBootLeft;
    [SerializeField] private SpriteRenderer spriteRendererLegLeft;
    [SerializeField] private SpriteRenderer spriteRendererBootRight;
    [SerializeField] private SpriteRenderer spriteRendererLegRight;
    [SerializeField] private SpriteRenderer spriteRendererPelvis;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textCoins.text = _coins.ToString();
    }

    public int GetCoins() 
    {
        return _coins;
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
        textCoins.text = _coins.ToString();
    }

    public void RemoveCoins(int coins) 
    {
        _coins -= coins;
        textCoins.text = _coins.ToString();
    }

    public void ChangeEquipedItem(ItemSO item)
    {
        if (item.idItem == _currentItemId)
            return;

        _currentItemId = item.idItem;

        if(item.type == ItemTypeEnum.Hood) 
        {
            spriteRendererHood.sprite = item.spritesEquipment.FirstOrDefault();
        }
        else
        {
            spriteRendererWristLeft.sprite = item.spritesEquipment.FirstOrDefault();
            spriteRendererElbowLeft.sprite = item.spritesEquipment[1];
            spriteRendererShoulderLeft.sprite = item.spritesEquipment[2];
            spriteRendererWristRight.sprite = item.spritesEquipment[3];
            spriteRendererElbowRight.sprite = item.spritesEquipment[4];
            spriteRendererShoulderRight.sprite = item.spritesEquipment[5];
            spriteRendererTorso.sprite = item.spritesEquipment[6];
            spriteRendererBootLeft.sprite = item.spritesEquipment[7];
            spriteRendererLegLeft.sprite = item.spritesEquipment[8];
            spriteRendererBootRight.sprite = item.spritesEquipment[9];
            spriteRendererLegRight.sprite = item.spritesEquipment[10];
            spriteRendererPelvis.sprite = item.spritesEquipment[11];
        }
    }
}
