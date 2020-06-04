using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Objet qui bouge après avoir recu du vent
    /// </summary>
    public class MovableObject : MonoBehaviour
    {
        [HideInInspector]
        public int SaveID = -1;
        public int powerStateRequest;

        public float duration;
        public float slowdown;

        Rigidbody2D rb;
        public bool isMoving;

        [Header("Audio")]
        public AudioClip boxMoving;
        public AudioClip heavyMoving;
        public AudioClip NarratorVoice53;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isMoving = false;
        }



        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                if (!isMoving && GameManager.Instance.powerState >= powerStateRequest)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / slowdown;
                    StartCoroutine(moveDuration());
                }
                else if (GameManager.Instance.powerState < powerStateRequest)
                {
                    if (!SoundManager.instance.voice53 && !SoundManager.instance.voiceSource.isPlaying)
                    {
                        SoundManager.instance.PlayVoices(NarratorVoice53, 1);
                        SoundManager.instance.voice53 = true;
                    }
                }
                
            }
            else if (other.CompareTag("GeneratorWave"))
            {
                if (!isMoving && powerStateRequest < 3)
                {
                    Debug.Log("I'm here");

                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / slowdown;
                    StartCoroutine(moveDuration());
                }
            }

        }
        /* private void OnCollisionEnter2D(Collision2D collision)
         {
             if (collision.collider.tag == "Player")
             {
                 rb.constraints = RigidbodyConstraints2D.FreezeAll;

             }

         }
         */


        IEnumerator moveDuration()
        {
            isMoving = true;
            
            if (powerStateRequest >= 3)
            {
                SoundManager.instance.PlaySfx(heavyMoving, 1, 1);
            }
            else
            {
                SoundManager.instance.PlaySfx(boxMoving, 0, 1);
            }

            
            yield return new WaitForSeconds(duration);
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}