using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AudioTrigger : MonoBehaviour
    {
        AudioSource triggerSound;
        bool haveBeenTrigger = false;

        void Start()
        {
            triggerSound = GetComponentInChildren<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if (haveBeenTrigger == false)
                {
                    triggerSound.enabled = true;
                    haveBeenTrigger = true;
                }
            }
        }

    }
}