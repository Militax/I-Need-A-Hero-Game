using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayMusicFadeIn : MonoBehaviour
    {
        AudioSource source;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            source.volume = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                while (source.volume < (SoundManager.instance.musicDefaultVolume * GetComponent<LinkAudioVolume>().volume))
                {
                    source.volume += 0.01f;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                while (source.volume > 0)
                {
                    source.volume -= 0.01f;
                }
            }
        }

    }
}