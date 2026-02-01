using UnityEngine;
using TMPro;
using System.Collections;

public class CarSpeed : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator driverAnimator;
    [SerializeField] private TMP_Text speedText;

    [Header("Speed Settings")]
    [SerializeField] private float currentSpeed = 0f;
    [SerializeField] private float normalSpeed = 60f;
    [SerializeField] private float maxSpeed = 120f;

    private bool phoneActive = false;
    private Coroutine speedRoutine;

    void Start()
    {
        speedRoutine = StartCoroutine(StartupAcceleration());
    }

    void Update()
    {
        bool phoneParam = driverAnimator.GetBool("Phone");

        if (phoneParam != phoneActive)
        {
            phoneActive = phoneParam;

            if (speedRoutine != null)
                StopCoroutine(speedRoutine);

            speedRoutine = phoneActive
                ? StartCoroutine(PhoneSpeedIncrease())
                : StartCoroutine(NormalSpeedVariation());
        }

        speedText.text = Mathf.RoundToInt(currentSpeed) + " mph";
    }

    IEnumerator StartupAcceleration()
    {
        float elapsed = 0f;
        float duration = 4f;

        while (elapsed < duration)
        {
            currentSpeed = Mathf.Lerp(0f, normalSpeed, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        currentSpeed = normalSpeed;
        speedRoutine = StartCoroutine(NormalSpeedVariation());
    }

    IEnumerator NormalSpeedVariation()
    {
        while (true)
        {
            float targetSpeed = Random.Range(55f, 65f);
            float startSpeed = currentSpeed;
            float t = 0f;

            while (t < 1f)
            {
                currentSpeed = Mathf.Lerp(startSpeed, targetSpeed, t);
                t += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator PhoneSpeedIncrease()
    {
        while (true)
        {
            currentSpeed = Mathf.Min(currentSpeed + 5f, maxSpeed);
            yield return new WaitForSeconds(2f);
        }
    }
}
