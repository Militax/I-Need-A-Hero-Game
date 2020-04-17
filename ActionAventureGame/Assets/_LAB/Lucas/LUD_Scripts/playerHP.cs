using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                TakeDamage();
            }
        }
        void TakeDamage()
        {
            GameManager.Instance.playerHealth -= 10;
            animator.SetTrigger("Hit");
        }
        private void Update()
        {
            if (GameManager.Instance.playerHealth <= 0)
            {
                animator.SetTrigger("Dead");
                Instantiate(DeathState, transform.position, Quaternion.identity);
                gameObject.transform.position = GameManager.Instance.RespawnPoint.transform.position;
                GameManager.Instance.DeathCounter += 1;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
        }
    }
}

