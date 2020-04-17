using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


namespace Player
{
    public class testAnimMort : MonoBehaviour
    {
        
        public GameObject respawnPoint;
        public GameObject DeathState;
        public Animator animator;
        void Start()
        {

            
        }
       
        void TakeDamage()
        {
            GameManager.Instance.playerHealth -= 10;
            animator.SetTrigger("Hit");
        }
        private void Update()
        {
            if (Input.GetKey("a"))
            {
                TakeDamage();
            }

            if (GameManager.Instance.playerHealth <= 0)
            {
                animator.SetTrigger("Dead");
                Instantiate(DeathState, transform.position, Quaternion.identity);
                gameObject.transform.position = respawnPoint.transform.position;
                GameManager.Instance.DeathCounter += 1;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
        }
    }
}

