using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeOutTexts : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public float delayBeforeFade = 3f;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;

        Color originalColor1 = text1.color;
        Color originalColor2 = text2.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            text1.color = new Color(originalColor1.r, originalColor1.g, originalColor1.b, alpha);
            text2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, alpha);

            yield return null;
        }

        text1.color = new Color(originalColor1.r, originalColor1.g, originalColor1.b, 0f);
        text2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 0f);
    }
}