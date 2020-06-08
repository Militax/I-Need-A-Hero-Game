using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureFeeForceVoice : MonoBehaviour
{
    public AudioClip voiceLine65;
    public AudioClip voiceLine66;


    public void Play65()
    {
        SoundManager.instance.PlayVoices(voiceLine65, 1);
    }
    public void Play66()
    {
        SoundManager.instance.PlayVoices(voiceLine66, 1);
    }
}