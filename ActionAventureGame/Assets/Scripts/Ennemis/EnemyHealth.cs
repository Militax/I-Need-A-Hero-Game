using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Ennemy;

namespace Ennemy
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère la vie du Gingerbread
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        #region Variables
        public string ennemyType;
        /*
        1.Gingerbread
        2.Snowman
        3.Chat
         */

        public float health;
        public float maximumHealth;
        public float safeTime;
        public bool isAlive = true;
        public float hitstun;
        bool isStunned = false;

        bool canTakeDamage = true;



        [Header("Loot")]
        public int dropNumber;
        public int lootRange;
        public GameObject[] myLoot;
		public GameObject[] coeur;
        #endregion
        Animator animator;
        bool Dead = false;
        public int TimerDie;
        public GameObject ParticleSystem;
        
        void Start()
        {
            health = maximumHealth;
            animator = gameObject.GetComponent<Animator>();
            
            
        }
        void Update()
        {
            if (health <= 0 && Dead == false)
            {
                Dead = true;
                //Debug.Log("die");
                if (ennemyType == "Gingerbread")
                {
                    this.GetComponent<GingerbreadMovement>().isAlive = false;
                    GetComponent<GingerbreadAttack>().enabled = false;
                }
                //Debug.Log("death");
                if (Dead == true)
                {
                    animator.SetTrigger("Death");
                    StartCoroutine(cooldown());
                }
                
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword") && ennemyType != ("Snowman") && canTakeDamage)
            {
                if (ennemyType == "Gingerbread" && !isStunned)
                {
                    StartCoroutine(Hitstun());
                }
                //Debug.Log(other);
                health -= GameManager.Instance.swordDamage;
                animator.SetTrigger("Degat");
                GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                Destroy(fx, 1f);
                StartCoroutine(SafeCooldown());
            }
            if (other.CompareTag("Slam") && ennemyType != ("Snowman") && canTakeDamage)
            {
                if (ennemyType == "Gingerbread" && !isStunned)
                {
                    StartCoroutine(Hitstun());
                }
                Debug.Log("degat");
                health -= GameManager.Instance.SlamDamage;
                animator.SetTrigger("Degat");
                StartCoroutine(SafeCooldown());
            }
            if (other.CompareTag("IceBullet") && canTakeDamage)
            {
                if (other.GetComponent<IceBullet>().isOut)//La balle est partie du Snowman
                {
                    Debug.Log("Hit");
                    animator.SetTrigger("Degat");
                    health--;
                    Destroy(other.gameObject);
                    StartCoroutine(SafeCooldown());
                }
            }
            if (other.CompareTag("BossBall") && canTakeDamage)
            {
                    Debug.Log("Hit");
                    animator.SetTrigger("Degat");
                    health--;
                    Destroy(other.gameObject);
                    StartCoroutine(SafeCooldown());
               
            }
        }


        void Death()
        {
            isAlive = false;
            Destroy(gameObject);
        }
        IEnumerator SafeCooldown()
        {

            canTakeDamage = false;
            yield return new WaitForSeconds(safeTime);
            canTakeDamage = true;
        }

       IEnumerator Hitstun()
        {
            isStunned = true;
            GetComponent<GingerbreadAttack>().canAttack = false;
            yield return new WaitForSeconds(hitstun);
            GetComponent<GingerbreadAttack>().canAttack = true;
            isStunned = false;
        }
        IEnumerator cooldown()
        {
            if (ennemyType == "Snowman")
            {
                GetComponentInChildren<SownmanFire>().enabled = false;
            }
            yield return new WaitForSeconds(TimerDie);
            GameManager.Instance.loot(dropNumber, lootRange, myLoot, this.gameObject);
			GameManager.Instance.loot(1, lootRange, coeur, this.gameObject);
            Destroy(gameObject);
        }
    }
}