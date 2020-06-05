using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChateauForestVoice : MonoBehaviour
{
    public AudioClip voiceLine23;


    public void Play23()
    {
        SoundManager.instance.PlayVoices(voiceLine23, 1);
    }
}