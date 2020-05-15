using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Ennemy;
using Boss;
using Audio;


namespace Player
{
    public class playerHP : MonoBehaviour
    {
        public GameObject DeathState;
        public Animator animator;
        bool isDying = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            
        }
        private void Update()
        {
            if (GameManager.Instance.playerHealth <= 0 && !isDying)
            {
                animator.SetTrigger("Dead");
                AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Death");
                isDying = true;
                Invoke("Respawn", animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }

        void Respawn()
        {
            Instantiate(DeathState, transform.position, Quaternion.identity);
            gameObject.transform.position = GameManager.Instance.RespawnPoint;
            GameManager.Instance.DeathCounter += 1;
            GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            isDying = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {

                case ("Bullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<Bullet>().damages;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Damage");
                    }
                    break;

                case ("IceBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<IceBullet>().damage;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Damage");
                    }
                    break;

                case ("LightBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<LightBall>().damage;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Damage");
                    }
                    break;
                case ("Cat"):
                    GameManager.Instance.playerHealth -= 1;
                    break;

                default:
                    break;

            }
        }
    }
}

