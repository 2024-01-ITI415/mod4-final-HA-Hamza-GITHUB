using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioClip newMusicClip; // The new music clip to play when the player enters the trigger zone
    public AudioClip ambientMusicClip; // The ambient music clip to play everywhere else in the scene
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isInTriggerZone = false; // Flag to track whether the player is in the trigger zone

    void Start()
    {
        // Get the AudioSource component attached to the AmbientMusicPlayer GameObject
        audioSource = GameObject.Find("AmbientMusicPlayer").GetComponent<AudioSource>();
        
        // Check if the AudioSource component exists
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on AmbientMusicPlayer GameObject.");
        }
        else
        {
            // Set the default ambient music clip
            audioSource.clip = ambientMusicClip;
            // Play the ambient music
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player"))
        {
            // Set the flag to true indicating the player is in the trigger zone
            isInTriggerZone = true;
            // Change the music clip to the newMusicClip and play it
            ChangeMusic(newMusicClip);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the trigger zone
        if (other.CompareTag("Player"))
        {
            // Set the flag to false indicating the player is not in the trigger zone
            isInTriggerZone = false;
            // Change the music clip back to the ambientMusicClip and play it
            ChangeMusic(ambientMusicClip);
        }
    }

    // Function to change the music clip and start playing it
    void ChangeMusic(AudioClip musicClip)
    {
        // Check if the audioSource reference is valid
        if (audioSource != null)
        {
            // Change the music clip played by the AudioSource
            audioSource.clip = musicClip;

            // Check if the music clip is not null before playing it
            if (musicClip != null)
            {
                // Play the new music clip
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("New music clip is null. Please assign a valid AudioClip to the newMusicClip variable.");
            }
        }
        else
        {
            Debug.LogWarning("AudioSource component not found on AmbientMusicPlayer GameObject.");
        }
    }
}
