using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class IntroBossVoice : MonoBehaviour
{
    public AudioClip voiceLine33;
    public AudioClip voiceLine34;
    public AudioClip voiceLine35;
    public AudioClip voiceLine36;
    public AudioClip voiceLine37;
    public AudioClip voiceLine38;

    public void Play33()
    {
        SoundManager.instance.PlayVoices(voiceLine33, 1);
    }
    public void Play34()
    {
        SoundManager.instance.PlayVoices(voiceLine34, 1);
    }
    public void Play35()
    {
        SoundManager.instance.PlayVoices(voiceLine35, 1);
    }
    public void Play36()
    {
        SoundManager.instance.PlayVoices(voiceLine36, 1);
    }
    public void Play37()
    {
        SoundManager.instance.PlayVoices(voiceLine37, 1);
    }
    public void Play38()
    {
        SoundManager.instance.PlayVoices(voiceLine38, 1);
    }


}