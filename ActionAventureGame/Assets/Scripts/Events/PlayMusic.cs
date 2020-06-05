using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip music;


    private void Start()
    {
        SoundManager.instance.PlayMusic(music, 1);
    }
}