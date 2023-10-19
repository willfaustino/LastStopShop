using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerAction : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupShop;

    public void ShowShop() 
    {
        canvasGroupShop.Show();
    }

    public void HideShop()
    {
        canvasGroupShop.Hide();
    }
}
