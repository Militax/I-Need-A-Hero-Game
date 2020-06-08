using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAudioVolume : MonoBehaviour
{
    AudioSource source;
    public bool isMusic;
    public bool isSfx;

    public float volume;

    void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        if (isMusic)
        {
            source.volume = SoundManager.instance.musicDefaultVolume * volume;
        }
        else if (isSfx)
        {
            source.volume = SoundManager.instance.sfxDefaultVolume * volume;
        }
        
    }


}