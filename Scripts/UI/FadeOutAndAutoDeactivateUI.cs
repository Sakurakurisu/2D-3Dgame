using UnityEngine;
using System.Collections;

public class FadeOutAndAutoDeactivateUI : MonoBehaviour
{
    public float fadeDuration = 1.5f; 

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        gameObject.SetActive(false);
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void ActivateAndAutoDeactivate()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 1;
        StartCoroutine(FadeOutAndDeactivate());
    }

    private IEnumerator FadeOutAndDeactivate()
    {
        yield return new WaitForSeconds(1);

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = 1 - (elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
