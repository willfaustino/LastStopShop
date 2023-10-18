using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffectTween : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        gameObject.transform.DOScale(0.9f, 0.15f).OnComplete(() => transform.DOScale(1f, 0.15f));
    }
}
