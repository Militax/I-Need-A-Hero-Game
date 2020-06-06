using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageVoice : MonoBehaviour
{
    public AudioClip voiceLine18;


    public void Play18()
    {
        SoundManager.instance.PlayVoices(voiceLine18, 1);
    }
}