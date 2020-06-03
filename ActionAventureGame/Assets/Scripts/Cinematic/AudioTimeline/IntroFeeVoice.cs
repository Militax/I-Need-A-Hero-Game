using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFeeVoice : MonoBehaviour
{
    public AudioClip voiceLine9;


    public void Play9()
    {
        SoundManager.instance.PlayVoices(voiceLine9, 1);
    }



}