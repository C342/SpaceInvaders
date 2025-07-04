using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 1f;
    [SerializeField] private float fadeDuration = 1f;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        canvasGroup.alpha -= Time.deltaTime / fadeDuration;
        if (canvasGroup.alpha <= 0f)
            Destroy(gameObject);
    }
}