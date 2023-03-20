using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraShake : MonoBehaviour
{
    public void Shake(float duration, float intensity)
    {
        StartCoroutine(ShakeCoroutine(duration, intensity));
    }

    private IEnumerator ShakeCoroutine(float duration, float intensity)
    {
        Vector3 originalPosition = GameManager.Instance.Cam.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = originalPosition.x + Random.Range(-1f, 1f) * intensity;
            float y = originalPosition.y + Random.Range(-1f, 1f) * intensity;

            transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        GameManager.Instance.Cam.transform.localPosition = originalPosition;
    }
}
