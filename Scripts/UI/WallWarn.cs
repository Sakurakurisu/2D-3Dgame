using System.Collections;
using UnityEngine;

public class WallWarn : MonoBehaviour
{
    public static WallWarn Instance;
    public float fadeDuration = 1.5f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void ActivateObject(bool isActive)
    {
        if (isActive)
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
            StartCoroutine(FadeOutAndDeactivate());
        }
        else
        {
            gameObject.SetActive(false);
        }
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
