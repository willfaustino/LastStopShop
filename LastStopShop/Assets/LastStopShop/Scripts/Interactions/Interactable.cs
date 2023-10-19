using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private UnityEvent interactEnterAction;
    [SerializeField] private UnityEvent interactExitAction;
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (gameObject.tag)
                {
                    case "CoinPurse":
                        Player.Instance.AddCoins(10);
                        interactEnterAction.Invoke();
                        break;

                    case "WoodenSign":
                        interactEnterAction.Invoke();
                        break;

                    case "Seller":
                        interactEnterAction.Invoke();
                        break;

                    case "Door":
                        interactEnterAction.Invoke();
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }

        switch (gameObject.tag)
        {
            case "WoodenSign":
                interactExitAction.Invoke();
                break;

            case "Seller":
                interactExitAction.Invoke();
                break;
        }
    }
}
