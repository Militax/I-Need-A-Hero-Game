using System.Collections;
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
                Invoke("Respawn", animator.GetCurrentAnimatorStateInfo(0).length);
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
            
            switch (other.tag)
            {
             
                case ("Bullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<Bullet>().damages;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        SoundManager.instance.PlaySfx(Damage, 1, 1);
                        animator.SetTrigger("Hit");
                    }
                    break;

                case ("IceBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<IceBullet>().damage;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        SoundManager.instance.PlaySfx(Damage, 1, 1);
                        animator.SetTrigger("Hit");
                    }
                    break;

                case ("LightBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<LightBall>().damage;
                    Destroy(other.gameObject);

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        SoundManager.instance.PlaySfx(Damage, 1, 1);
                        animator.SetTrigger("Hit");
                    }
                    break;
                case ("Cat"):
                    GameManager.Instance.playerHealth -= 1;
                    animator.SetTrigger("Hit");
                    SoundManager.instance.PlaySfx(Damage, 1, 1);
                    Debug.Log("attack");
                    break;
                
                    
                    
                default:
                    break;

            }
        }
    }
}

