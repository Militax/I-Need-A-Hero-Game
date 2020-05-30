using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAudioVolume : MonoBehaviour
{
    AudioSource source;

    void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        source.volume = SoundManager.instance.sfxDefaultVolume;
    }


}