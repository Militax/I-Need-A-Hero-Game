using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogVoice : MonoBehaviour
{
    public AudioClip voiceLine67;


    public void Play67()
    {
        SoundManager.instance.PlayVoices(voiceLine67, 1);
    }
}