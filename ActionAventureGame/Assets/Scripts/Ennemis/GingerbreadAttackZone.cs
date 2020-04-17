using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

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


        void Update()
        {
            if (attackIsAsked && !isInCoroutine)
            {
                StartCoroutine(Duration());
            }
            if (isInZone && attackIsAsked && canDamage)
            {
                Debug.Log("Taking Damage");
                GameManager.Instance.playerHealth--;
                canDamage = false;
            }
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