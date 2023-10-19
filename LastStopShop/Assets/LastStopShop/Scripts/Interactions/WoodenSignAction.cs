using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodenSignAction : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupMessage;
    [SerializeField] private Button buttonCloseMessage;

    private void Start()
    {
        buttonCloseMessage.onClick.AddListener(HideMessage);
    }

    public void ShowMessage()
    {
        canvasGroupMessage.Show();
    }

    public void HideMessage()
    {
        canvasGroupMessage.Hide();
    }
}
