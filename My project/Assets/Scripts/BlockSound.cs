using UnityEngine;

public class BlockSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on " + gameObject.name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasPlayed && audioSource != null)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }
}
