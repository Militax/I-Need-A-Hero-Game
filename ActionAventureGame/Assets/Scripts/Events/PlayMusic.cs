using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public bool onStart;
    public bool ifTrigger;
    public bool needToLoop;

    public AudioClip music;


    private void Start()
    {
        if (onStart)
        {
            if (needToLoop)
            {
                SoundManager.instance.musicSource.loop = true;
            }
            SoundManager.instance.PlayMusic(music, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(ifTrigger && other.tag == "PlayerFeet")
        {
            if (needToLoop)
            {
                SoundManager.instance.musicSource.loop = true;
            }

            SoundManager.instance.PlayMusic(music, 1);
            Destroy(gameObject);
        }
    }
}