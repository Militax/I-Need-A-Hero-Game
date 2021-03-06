﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Ennemy;
using Boss;


namespace Player
{
    public class playerHP : MonoBehaviour
    {
        public GameObject DeathState;
        public Animator animator;
        bool isDying = false;

        [Header("SFX")]
        public AudioClip Death;
        public AudioClip Damage;

        [Header("Voices")]
        public AudioClip NarratorVoice61;
        public AudioClip NarratorVoice49;
        public AudioClip NarratorVoice55;

        public float invulnerabilityDuration;
        void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (GameManager.Instance.playerHealth <= 0 && !isDying)
            {
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                animator.SetTrigger("Dead");
                SoundManager.instance.PlaySfx(Death, 1, 1);
                isDying = true;
                SoundManager.instance.PlayVoices(NarratorVoice61, 1);
                Invoke("Respawn", animator.GetCurrentAnimatorStateInfo(0).length);
            }




            if (GameManager.Instance.playerHealth < 3)
            {
                if (!SoundManager.instance.voice55 && !SoundManager.instance.voiceSource.isPlaying)
                {
                    SoundManager.instance.PlayVoices(NarratorVoice55, 1);
                    SoundManager.instance.voice55 = true;
                }
            }
        }

        void Respawn()
        {
            
            Instantiate(DeathState, transform.position, Quaternion.identity);
            gameObject.transform.position = GameManager.Instance.RespawnPoint;
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<PlayerAttack>().enabled = true;
            gameObject.GetComponent<PlayerPowers>().enabled = true;
            GameManager.Instance.DeathCounter += 1;
            GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            isDying = false;
        }

        


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (GameManager.Instance.invulnerability == false)
            {
                switch (other.tag)
                {

                    case ("Bullet"):
                        GameManager.Instance.playerHealth -= other.GetComponent<Bullet>().damages;
                        Destroy(other.gameObject);

                        if (GameManager.Instance.playerHealth > 0)
                        {
                            SoundManager.instance.PlaySfx(Damage, 1, 1);
                            animator.SetTrigger("Hit");
                            GameManager.Instance.invulnerability = true;


                            if (!SoundManager.instance.voice49 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice49, 1);
                                SoundManager.instance.voice49 = true;
                            }
                        }
                        break;

                    case ("IceBullet"):
                        GameManager.Instance.playerHealth -= other.GetComponent<SnowBullet>().damage;
                        Destroy(other.gameObject);

                        if (GameManager.Instance.playerHealth > 0)
                        {
                            SoundManager.instance.PlaySfx(Damage, 1, 1);
                            animator.SetTrigger("Hit");
                            GameManager.Instance.invulnerability = true;

                            if (!SoundManager.instance.voice49 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice49, 1);
                                SoundManager.instance.voice49 = true;
                            }
                        }
                        break;

                    case ("LightBullet"):
                        GameManager.Instance.playerHealth -= other.GetComponent<LightBall>().damage;
                        Destroy(other.gameObject);

                        if (GameManager.Instance.playerHealth > 0)
                        {
                            SoundManager.instance.PlaySfx(Damage, 1, 1);
                            animator.SetTrigger("Hit");
                            GameManager.Instance.invulnerability = true;

                            if (!SoundManager.instance.voice49 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice49, 1);
                                SoundManager.instance.voice49 = true;
                            }
                        }
                        break;
                    case ("Cat"):
                        GameManager.Instance.playerHealth -= 1;
                        animator.SetTrigger("Hit");
                        SoundManager.instance.PlaySfx(Damage, 1, 1);
                        if (!SoundManager.instance.voice49 && !SoundManager.instance.voiceSource.isPlaying)
                        {
                            SoundManager.instance.PlayVoices(NarratorVoice49, 1);
                            SoundManager.instance.voice49 = true;
                        }
                        //Debug.Log("attack");
                        GameManager.Instance.invulnerability = true;
                        
                        break;



                    default:
                        break;

                }
            }
            
        }
    }
}

