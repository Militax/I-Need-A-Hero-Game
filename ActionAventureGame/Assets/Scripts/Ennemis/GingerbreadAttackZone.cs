using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

namespace Ennemy
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Zone d'attaque du Gingerbread
    /// </summary>
    public class GingerbreadAttackZone : MonoBehaviour
    {
        public float duration;

        public bool attackIsAsked = false;
        bool canDamage = true;
        bool isInZone = false;
        bool isInCoroutine = false;

        [Header("SFX")]
        public AudioClip Damage;

        //public GameObject Player;
        Animator animator;

        private void Start()
        {
            animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }

        void Update()
        {
            if (attackIsAsked && !isInCoroutine)
            {
                StartCoroutine(Duration());
            }
            if (isInZone && attackIsAsked && canDamage && GameManager.Instance.player.GetComponent<playerHP>().invulnerability == false)
            {
                Debug.Log("Taking Damage");
                GameManager.Instance.playerHealth--;
                GameManager.Instance.player.GetComponent<playerHP>().invulnerability = true;
                Invoke("ResetInvulnerability", GameManager.Instance.player.GetComponent<playerHP>().invulnerabilityDuration);
                SoundManager.instance.PlaySfx(Damage, 1, 1);
                animator.SetTrigger("Hit");
                canDamage = false;
            }
        }

        void ResetInvulnerability()
        {
            GameManager.Instance.player.GetComponent<playerHP>().invulnerability = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInZone = true;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInZone = false;
            }
        }




        IEnumerator Duration()
        {
            isInCoroutine = true;
            yield return new WaitForSeconds(duration);
            attackIsAsked = false;
            canDamage = true;
            isInCoroutine = false;
        }

    }
}