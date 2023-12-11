using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class AudioTrigger : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audioSource;
    public bool alreadyPlayed = false;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponentInChildren<Image>();
    }

    void OnTriggerEnter()
    {
<<<<<<< HEAD
        //if(!alreadyPlayed)
        //{
        //    audioSource.PlayOneShot(SoundToPlay, Volume);
        //    alreadyPlayed = true;
        //}
	PlayTheSoundClip();
=======
        if(!alreadyPlayed)
        {
            audioSource.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
    }

    public void PlayTheSoundClip()
    {
        // Try and get the audio clip set by the localization manager
        AudioClip sourceClip = null;
        if (audioSource != null && audioSource.clip != null)
        {
            sourceClip = audioSource.clip;
            Debug.Log("[AUDIO::DEBUG] AudioClip name = " + sourceClip.name);
        }

        if (!alreadyPlayed)
        {
            Debug.Log("[AUDIO::DEBUG] Playing the audio source.");
            // Play the clip set by the localization manager if it was there, if not
            // just play the default clip
            if (sourceClip != null)
            {
                audioSource.PlayOneShot(sourceClip, Volume);
            }
            else
            {
                audioSource.PlayOneShot(SoundToPlay, Volume);
            }
            alreadyPlayed = true;
        }
    }

    void Update()
    { 
        if(alreadyPlayed)
        {
            if (image != null)
            {
                image.GetComponent<VoiceDone>().isOn = true;
            }
        }
    }
}
