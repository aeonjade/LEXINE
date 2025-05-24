using System.Collections;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    private const float FADE_DELAY = 0.5f;

    public void FadeIn(CanvasGroup canvasGroup)
    {
        StartCoroutine(FadeInCoroutine(canvasGroup));
    }

    private IEnumerator FadeInCoroutine(CanvasGroup canvasGroup)
    {
        yield return new WaitForSeconds(FADE_DELAY);
        FadeInDelayed(canvasGroup);
    }

    private void FadeInDelayed(CanvasGroup canvasGroup)
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
