using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerAction : MonoBehaviour
{
    public void ShowShop() 
    {
        Shop.Instance.canvasGroupShop.Show();
        Player.Instance.SetIsShopping(true);
    }

    public void HideShop()
    {
        Shop.Instance.canvasGroupShop.Hide();
        Player.Instance.SetIsShopping(false);
    }
}
