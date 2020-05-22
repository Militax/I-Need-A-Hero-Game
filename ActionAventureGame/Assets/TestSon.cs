using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TestSon : MonoBehaviour
    {
        public AudioClip son;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                SoundManager.instance.PlayMusic(son, 1);
            }
        }

    }
}