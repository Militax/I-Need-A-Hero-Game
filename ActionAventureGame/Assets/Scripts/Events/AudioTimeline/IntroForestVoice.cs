using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroForestVoice : MonoBehaviour
{
    public AudioClip voiceLine1;
    public AudioClip voiceLine2;
    public AudioClip voiceLine3;
    public AudioClip voiceLine4;
    public AudioClip voiceLine5;
    public AudioClip voiceLine6;
    public AudioClip voiceLine7;


    public void Play1 ()
    {
        SoundManager.instance.PlayVoices(voiceLine1, 1);
    }
    public void Play2()
    {
        SoundManager.instance.PlayVoices(voiceLine2, 1);
    }
    public void Play3()
    {
        SoundManager.instance.PlayVoices(voiceLine3, 1);
    }
    public void Play4()
    {
        SoundManager.instance.PlayVoices(voiceLine4, 1);
    }
    public void Play5()
    {
        SoundManager.instance.PlayVoices(voiceLine5, 1);
    }
    public void Play6()
    {
        SoundManager.instance.PlayVoices(voiceLine6, 1);
    }
    public void Play7()
    {
        SoundManager.instance.PlayVoices(voiceLine7, 1);
    }
}