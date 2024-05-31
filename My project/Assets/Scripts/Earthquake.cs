using UnityEngine;
using System.Collections;

public class Earthquake : MonoBehaviour
{
    public float duration = 2.0f; // Duración del terremoto
    public float magnitude = 0.1f; // Magnitud del terremoto

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void StartEarthquakeRoutine()
    {
        StartCoroutine(StartEarthquake());
    }

    IEnumerator StartEarthquake()
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z + z);

            yield return null;
        }

        transform.position = originalPosition;
    }
}
