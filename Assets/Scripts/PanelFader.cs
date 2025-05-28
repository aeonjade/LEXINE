using System.Collections;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup introCanvasGroup;
    public float fadeDuration = 0.5f;
    private const float FADE_DELAY = 0.5f;

    void Start()
    {
        StartCoroutine(InitialFadeCoroutine());
    }

    private IEnumerator InitialFadeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        FadeInDelayed(introCanvasGroup);
    }

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
        LeanTween.alphaCanvas(canvasGroup, 1f, fadeDuration)
            .setOnStart(() =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });
    }

    public void FadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        LeanTween.alphaCanvas(canvasGroup, 0f, fadeDuration);
    }


}
