using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroChateauVoice : MonoBehaviour
{
    public AudioClip voiceLine24;


    public void Play24()
    {
        SoundManager.instance.PlayVoices(voiceLine24, 1);
    }
}