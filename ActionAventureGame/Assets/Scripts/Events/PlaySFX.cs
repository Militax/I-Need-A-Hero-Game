using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public bool onStart;
    public bool ifTrigger;

    [Range(0f, 1f)] public float volume;

    public AudioClip SFX;


    private void Start()
    {
        if (onStart)
        {
            SoundManager.instance.PlaySfx(SFX, volume, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ifTrigger && other.tag == "PlayerFeet")
        {
            SoundManager.instance.PlaySfx(SFX, volume, 1);
            Destroy(gameObject);
        }
    }


    public void PlaySong()
    {
        SoundManager.instance.PlaySfx(SFX, volume, 1);
    }
}