using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageVoice : MonoBehaviour
{
    public AudioClip voiceLine22;


    public void Play22()
    {
        SoundManager.instance.PlayVoices(voiceLine22, 1);
    }
}