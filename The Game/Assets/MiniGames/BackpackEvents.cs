using System.Collections;
using UnityEngine;

public class BackpackEvents : MonoBehaviour
{
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public float shakeAmount = 10f;
    public float shakeDuration = 0.7f;

    private Vector3 originalPosition;

    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float timeElapsed = 0f;

        while (timeElapsed < shakeDuration)
        {
            transform.localPosition = originalPosition + (Vector3)(Random.insideUnitCircle * shakeAmount);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
