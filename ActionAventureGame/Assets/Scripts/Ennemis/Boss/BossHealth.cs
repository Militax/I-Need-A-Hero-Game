using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BossHealth : MonoBehaviour
    {
        #region Variables
        public int CurrentBossLife;
        public int maxBossLife;

        bool canTakeDamage= true;

        public Animator animator;
        #endregion


        void Start()
        {
            CurrentBossLife = maxBossLife;
        }
        void Update()
        {
            if (CurrentBossLife <= 0)
            {
                Death();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter");
            if (other.CompareTag("Sword") || other.CompareTag("IceBullet"))
            {
                Debug.Log("Damage " + CurrentBossLife);
                CurrentBossLife--;
            }
        }


        void Death()
        {
            Debug.Log("Death");
            animator.SetTrigger("Dead");
            Destroy(gameObject);
        }
    }
}