using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroVoice : MonoBehaviour
{
    public AudioClip voiceLine42;
    public AudioClip aubane;


    public void Play42()
    {
        SoundManager.instance.PlayVoices(voiceLine42, 1);
    }
    public void PlayAubane()
    {
        SoundManager.instance.PlayVoices(aubane, 1);
    }
}