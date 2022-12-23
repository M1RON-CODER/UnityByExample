using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Shake(3, 0.3f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float shakeX = Random.Range(-1f, 1f) * magnitude;
            float shakeY = Random.Range(-1f, 1f) * magnitude;

            transform.position = Vector3.Slerp(new Vector3(startPosition.x, startPosition.y, startPosition.z),
                new Vector3(startPosition.x + shakeX, startPosition.y + shakeY, startPosition.z), 0.2f);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
