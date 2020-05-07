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


        void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (GameManager.Instance.playerHealth <= 0)
            {
                animator.SetTrigger("Dead");
                Instantiate(DeathState, transform.position, Quaternion.identity);
                gameObject.transform.position = GameManager.Instance.RespawnPoint;
                GameManager.Instance.DeathCounter += 1;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {

                case ("Bullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<Bullet>().damages;
                    Destroy(other.gameObject);
                    break;

                case ("IceBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<IceBullet>().damage;
                    Destroy(other.gameObject);
                    break;

                case ("LightBullet"):
                    GameManager.Instance.playerHealth -= other.GetComponent<LightBall>().damage;
                    Destroy(other.gameObject);
                    break;

                default:
                    break;

            }
        }
    }
}

