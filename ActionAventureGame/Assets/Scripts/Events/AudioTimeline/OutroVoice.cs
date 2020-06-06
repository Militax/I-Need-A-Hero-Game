using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroVoice : MonoBehaviour
{
    public AudioClip voiceLine42;


    public void Play42()
    {
        SoundManager.instance.PlayVoices(voiceLine42, 1);
    }
}