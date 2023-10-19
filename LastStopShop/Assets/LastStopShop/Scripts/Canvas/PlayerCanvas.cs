using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    private int _coins = 10;

    [Header("Canvas Player")]
    [SerializeField] private Slider sliderHealthPoints;
    [SerializeField] private Button buttonInventory;
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private CanvasGroup canvasGroupInventory;

    void Start()
    {
        buttonInventory.onClick.AddListener(() => canvasGroupInventory.Show());
    }


}
