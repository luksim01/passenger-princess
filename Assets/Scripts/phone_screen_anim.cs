using UnityEngine;
using System.Collections;

public class PhoneScreenAnim : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator driverAnimator;
    [SerializeField] private Renderer phoneRenderer;

    [Header("Emission Settings")]
    [SerializeField] private Color emissionColor = Color.white;
    [SerializeField] private float emissionStart = 0f;
    [SerializeField] private float emissionEnd = 2f;
    [SerializeField] private float animationDuration = 1f;

    private MaterialPropertyBlock mpb;
    public bool isOn = false;

    bool phoneParam;
    private Coroutine emissionRoutine;

    void Awake()
    {
        mpb = new MaterialPropertyBlock();
    }

    void Update()
    {
        isOn = driverAnimator.GetBool("Phone");

        if (!isOn)
        {
            TurnOnScreen();
        }
        else if (isOn)
        {
            TurnOffScreen();
        }
    }

    void TurnOnScreen()
    {
        if (emissionRoutine != null)
            StopCoroutine(emissionRoutine);

        emissionRoutine = StartCoroutine(AnimateEmission(emissionStart, emissionEnd));
    }

    void TurnOffScreen()
    {
        if (emissionRoutine != null)
            StopCoroutine(emissionRoutine);

        emissionRoutine = StartCoroutine(AnimateEmission(emissionEnd, emissionStart));
    }

    IEnumerator AnimateEmission(float from, float to)
    {
        float t = 0f;

        while (t < animationDuration)
        {
            float intensity = Mathf.Lerp(from, to, t / animationDuration);

            phoneRenderer.GetPropertyBlock(mpb);
            mpb.SetColor("_EmissionColor", emissionColor * intensity);
            phoneRenderer.SetPropertyBlock(mpb);

            t += Time.deltaTime;
            yield return null;
        }

        // Final value
        phoneRenderer.GetPropertyBlock(mpb);
        mpb.SetColor("_EmissionColor", emissionColor * to);
        phoneRenderer.SetPropertyBlock(mpb);
    }
}
