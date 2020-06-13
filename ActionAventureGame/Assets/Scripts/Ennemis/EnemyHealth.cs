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
        

        CatBehaviourProto MyCat;
        public float health;
        public float maximumHealth;
        public float safeTime;
        public bool isAlive = true;
        public float hitstun;
        bool isStunned = false;
        

        [HideInInspector]
        public bool canTakeDamage = true;



        [Header("Loot")]
        public int dropNumber;
        public int lootRange;
        public GameObject[] myLoot;
		public GameObject[] coeur;
        #endregion
        Animator animator;
        bool Dead = false;
        public float TimerDie;
        public GameObject ParticleSystem;


        [Header("Voices")]
        public AudioClip NarratorVoice8;
        public AudioClip NarratorVoice25;
        public AudioClip NarratorVoice51;
        public AudioClip NarratorVoice52;

        [Header("Audio")]
        public AudioClip GbDamage1;
        public AudioClip GbDamage2;
        public AudioClip GbDamage3;
        public AudioClip CatDamage;
        public AudioClip SmDamage;


        void Start()
        {
            health = maximumHealth;
            animator = gameObject.GetComponent<Animator>();
            MyCat = GetComponent<CatBehaviourProto>();
        }
        void Update()
        {
            if (health <= 0 && Dead == false)
            {
                Dead = true;

                //Debug.Log("death");
                if (Dead == true)
                {
                    animator.SetBool("Death", true);
                    StartCoroutine(cooldown());


                    //---------------------------------Voix du narrateur-------------------------------------
                    switch(GameManager.Instance.NarrativeStat)
                    {
                        case (1):
                            if (!SoundManager.instance.voice8 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice8, 1);
                                SoundManager.instance.voice8 = true;
                            }
                            break;

                        case (2):
                            if (!SoundManager.instance.voice25 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice25, 1);
                                SoundManager.instance.voice25 = true;
                            }
                            break;

                        case (3):
                            if (!SoundManager.instance.voice51 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice51, 1);
                                SoundManager.instance.voice51 = true;
                            }
                            break;

                        case (4):
                            if (!SoundManager.instance.voice52 && !SoundManager.instance.voiceSource.isPlaying)
                            {
                                SoundManager.instance.PlayVoices(NarratorVoice52, 1);
                                SoundManager.instance.voice52 = true;
                            }
                            break;

                        default:
                            break;
                    }
                    //----------------------------------------------------------------------------------------
                }
                
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword") && ennemyType != ("Snowman") && canTakeDamage)
            {
                if (ennemyType == "Gingerbread" && !isStunned)
                {
                    PlayGbDamageSound();
                }
                //Debug.Log(other);
                if (ennemyType == "Cat")
                {
                    if (MyCat.isPushed)
                    {
                        animator.SetBool("isPushed", false);
                    }                    else if (ennemyType == "Snowman")
                    {
                        SoundManager.instance.PlaySfx(SmDamage, 1, 1);
                    }
                    else
                    {
                        animator.SetBool("isPushed", true);
                    }                    SoundManager.instance.PlaySfx(CatDamage, 1, 1);
                }
                health -= GameManager.Instance.swordDamage;
                animator.SetTrigger("Degat");
                GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                Destroy(fx, 1f);
                StartCoroutine(SafeCooldown());
            }
            if (other.CompareTag("Slam") && ennemyType != ("Snowman") && canTakeDamage)
            {
                if (ennemyType == "Gingerbread" && !isStunned)
                {                    PlayGbDamageSound();
                }
                health -= GameManager.Instance.SlamDamage;
                animator.SetTrigger("Degat");
                StartCoroutine(SafeCooldown());
            }
            if (other.CompareTag("IceBullet") && canTakeDamage)
            {
                if (other.GetComponent<SnowBullet>().isOut)//La balle est partie du Snowman
                {
                    if (ennemyType == "Snowman")
                    {
                        SoundManager.instance.PlaySfx(SmDamage, 1, 1);
                    }
                    animator.SetTrigger("Degat");
                    health--;
                    Destroy(other.gameObject);
                    StartCoroutine(SafeCooldown());
                }
            }
            if (other.CompareTag("BossBall") && canTakeDamage)
            {
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
            isAlive = false;
            if (ennemyType == "Snowman")
            {
                GetComponent<SnowMenBehaviour>().isDead = true;
            }
            if (ennemyType == "Gingerbread")
            {
                GetComponent<GingerBreadBehaviour>().isDead = true;
            }
            if (ennemyType == "Cat")
            {
                GetComponent<CatBehaviourProto>().isDead = true;
            }
            yield return new WaitForSeconds(TimerDie);
            GameManager.Instance.loot(dropNumber, lootRange, myLoot, this.gameObject);
			GameManager.Instance.loot(1, lootRange, coeur, this.gameObject);
            Destroy(gameObject);
        }






        void PlayGbDamageSound()
        {
            int token = Random.Range(1, 4);

            switch (token)
            {
                case (1):
                    SoundManager.instance.PlaySfx(GbDamage1, 1, 1);
                    break;

                case (2):
                    SoundManager.instance.PlaySfx(GbDamage2, 1, 1);
                    break;

                case (3):
                    SoundManager.instance.PlaySfx(GbDamage3, 1, 1);
                    break;
            }
        }
    }
}