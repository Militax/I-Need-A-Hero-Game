using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Player
{

    /// <summary>
    /// Lucas Deutschmann
    /// 
    ///  | Colliders d'attaque
    /// </summary>
    public class AttackColliders : MonoBehaviour
    {
        

        public void deactivate()
        {
            
            gameObject.transform.localScale = Vector3.zero;
            GameManager.Instance.player.GetComponent<PlayerAttack>().isAttacking = false;
        }

        public void deSpawn()
        {
            GameManager.Instance.player.GetComponent<PlayerAttack>().isAttacking = false;
            //Debug.Log("poof");
            Destroy(GameObject.FindGameObjectWithTag("Slam"));
        }
    }
}