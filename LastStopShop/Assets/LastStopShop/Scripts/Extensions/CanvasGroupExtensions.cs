using UnityEngine;
using DG.Tweening;

public static class CanvasGroupExtensions
{
    public static void Show(this CanvasGroup canvas)
    {
        canvas.DOFade(1, 0.4f).OnComplete(() =>
        {
            canvas.blocksRaycasts = true;
        });
    }

    public static void Hide(this CanvasGroup canvas, System.Action callback = null)
    {
        canvas.blocksRaycasts = false;
        canvas.DOFade(0, 0.4f).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }
}
