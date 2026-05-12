using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonAnimationController : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Scale")]
    [SerializeField] float hoverScale = 1.15f;
    [SerializeField] float animationSpeed = 10f;

    [Header("Colors")]
    [SerializeField] Color hoverTint = new Color(0.7f, 0.7f, 0.7f);
    [SerializeField] Color pressedTint = new Color(0.1f, 0.2f, 0.5f);

    private Vector3 targetScale = Vector3.one;
    private Coroutine scaleRoutine;

    private Image[] images;
    private TMP_Text[] texts;

    private Color[] originalImageColors;
    private Color[] originalTextColors;

    private bool isHovering;

    void Start()
    {
        images = GetComponentsInChildren<Image>(true);
        texts = GetComponentsInChildren<TMP_Text>(true);

        // Guardar colores originales
        originalImageColors = new Color[images.Length];
        for (int i = 0; i < images.Length; i++)
            originalImageColors[i] = images[i].color;

        originalTextColors = new Color[texts.Length];
        for (int i = 0; i < texts.Length; i++)
            originalTextColors[i] = texts[i].color;

        SetTint(Color.white);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        AnimateScale(Vector3.one * hoverScale);
        SetTint(hoverTint);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        AnimateScale(Vector3.one);
        SetTint(Color.white);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetTint(pressedTint);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetTint(isHovering ? hoverTint : Color.white);
    }

    void AnimateScale(Vector3 newScale)
    {
        targetScale = newScale;

        if (scaleRoutine != null)
            StopCoroutine(scaleRoutine);

        scaleRoutine = StartCoroutine(ScaleRoutine());
    }

    IEnumerator ScaleRoutine()
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.001f)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                targetScale,
                Time.deltaTime * animationSpeed
            );

            yield return null;
        }

        transform.localScale = targetScale;
    }

    void SetTint(Color tint)
    {
        for (int i = 0; i < images.Length; i++)
            images[i].color = originalImageColors[i] * tint;

        for (int i = 0; i < texts.Length; i++)
            texts[i].color = originalTextColors[i] * tint;
    }
}