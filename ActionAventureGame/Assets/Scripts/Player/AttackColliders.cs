using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    /// <summary>
    /// Lucas Deutschmann
    /// 
    ///  | Colliders d'attaque
    /// </summary>
    public class AttackColliders : MonoBehaviour
    {
        public float attackduration;
        private void OnEnable()
        {
            attackduration = GetComponentInParent<PlayerAttack>().attackDuration;
            StartCoroutine(deactivate());
        }

        IEnumerator deactivate()
        {
            yield return new WaitForSeconds(attackduration);
            gameObject.SetActive(false);
        }
    }
}