using UnityEngine;

public class PanelFader : MonoBehaviour
{
    public float fadeDuration = 0.5f;

    public void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.gameObject.SetActive(true);
        LeanTween.alphaCanvas(canvasGroup, 1f, fadeDuration)
            .setOnStart(() =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });
    }

    public void FadeOut(CanvasGroup canvasGroup)
    {
        LeanTween.alphaCanvas(canvasGroup, 0f, fadeDuration)
            .setOnComplete(() =>
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.gameObject.SetActive(false);
            });
    }
}
