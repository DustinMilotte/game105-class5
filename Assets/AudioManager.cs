using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixerGroup sfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public static AudioSource PlayClipAtPoint(AudioClip clip, Vector3 position,
       AudioMixerGroup mixerGroup)
    {
        /*
         We wrote this method so we can:
         1. play pick up sound after pick up object is no longer active in scene
         2. play that sound on a certain mixer group
        */

        // create temporary gameObject
        GameObject gameObject = new GameObject("TempAudioObject");
        //set its position to the position we take as input parameter
        gameObject.transform.position = position;
        //create audio source
        var audioSource = gameObject.AddComponent<AudioSource>();
        //set its clip to input parameter clip
        audioSource.clip = clip;
        // set its mixer group
        audioSource.outputAudioMixerGroup = mixerGroup;
        // destroy this object when the audio clip has finished
        Destroy(gameObject, clip.length);
        // play the clip
        audioSource.Play();
        // return the audio source
        return audioSource;
    }
}
