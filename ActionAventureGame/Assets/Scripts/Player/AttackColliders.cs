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
        public float slamduration;

        public void deactivate()
        {
            
            gameObject.transform.localScale = Vector3.zero;
            GameManager.Instance.player.GetComponent<PlayerAttack>().isAttacking = false;
        }

        
        public void deSpawn()
        {
            GameManager.Instance.player.GetComponent<PlayerAttack>().isAttacking = false;
            GameObject.FindGameObjectWithTag("Slam").GetComponent<Collider2D>().enabled = false;
            Invoke("destroySlam", slamduration);
        }
        void destroySlam()
        {
            Destroy(GameObject.FindGameObjectWithTag("Slam"));
        }
    }
}