using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayThisSong(string clipName, float volumeMultiplayer)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeMultiplayer;
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clipName, typeof(AudioClip)));
    }
}
