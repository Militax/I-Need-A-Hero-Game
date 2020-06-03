using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GingerbreadVoice : MonoBehaviour
{
    public AudioClip voiceLine14;


    public void Play14()
    {
        SoundManager.instance.PlayVoices(voiceLine14, 1);
    }



}