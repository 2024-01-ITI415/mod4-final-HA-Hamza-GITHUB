using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip newAudioClip; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.clip = newAudioClip;
            audioSource.Play();
        }
    }
}