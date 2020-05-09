using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Ennemy
{
    public class PowerEnnemyInteraction : MonoBehaviour
    {

        #region Variables
        public float windEffectSlowdown;
        public float windEffectDuration;
        public float freezEffectDuration;

        string ennemyType;
        Rigidbody2D rb;
        #endregion
        public Animator animator;

        void Start()
        {
            ennemyType = this.GetComponent<EnemyHealth>().ennemyType;
            rb = GetComponent<Rigidbody2D>();
            animator.GetComponent<Animator>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                if (ennemyType == "Gingerbread")
                {
                    
                    if (GetComponent<GingerbreadMovement>().isAffectedByWind == false)
                    {
                        if (GameManager.Instance.powerState >= 2)
                        {
                            Debug.Log("hihihih");
                            StartCoroutine(FreezeEffect(other));
                        }
                        else
                        {
                            StartCoroutine(WindEffect(other));
                        }
                        
                    }
                }
                else
                {
                    StartCoroutine(WindEffect(other));
                }
            }
            
        }


        //Temps ou l'ennemi est repoussé
        IEnumerator WindEffect(Collider2D other)
        {
            switch (ennemyType)
            {

                case ("Gingerbread")://Sur le gingerbread

                    GetComponent<GingerbreadMovement>().isAffectedByWind = true;                 
                    rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                    yield return new WaitForSeconds(windEffectDuration);
                    rb.velocity = Vector2.zero;
                    yield return new WaitForSeconds(windEffectDuration);
                    GetComponent<GingerbreadMovement>().isAffectedByWind = false;

                    break;


                case ("Chat")://Sur le chat
                    break;


                case ("Snowman")://Sur le SnowMan

                    if (GameManager.Instance.powerState == 3)
                    {
                        rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                        yield return new WaitForSeconds(windEffectDuration);
                        rb.velocity = Vector2.zero;
                    }

                    break;

            }
        }
        IEnumerator FreezeEffect(Collider2D other)
        {
            switch (ennemyType)
            {

                case ("Gingerbread")://Sur le gingerbread

                    GetComponent<GingerbreadMovement>().isAffectedByWind = true;
                    rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                    yield return new WaitForSeconds(windEffectDuration);
                    rb.velocity = Vector2.zero;
                    Debug.Log(animator);
                    animator.SetTrigger("Freeze");

                    yield return new WaitForSeconds(freezEffectDuration);
                    GetComponent<GingerbreadMovement>().isAffectedByWind = false;

                    break;


                case ("Chat")://Sur le chat
                    break;


                case ("Snowman")://Sur le SnowMan

                    if (GameManager.Instance.powerState == 3)
                    {
                        rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                        yield return new WaitForSeconds(windEffectDuration);
                        rb.velocity = Vector2.zero;
                    }

                    break;

            }
        }
    }
}