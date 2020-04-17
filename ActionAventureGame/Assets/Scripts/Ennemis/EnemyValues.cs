using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Ennemy
{

    /// <summary>
    /// Louis Lefebvre
    /// 
    ///  | Valeurs communes à tous les ennemis
    /// </summary>
    public class EnemyValues : MonoBehaviour
    {

        #region Attack
        public int attackDamage;
        public float attackCooldown;
        public bool canAttack = true;
        public bool isAttacking = false;
        #endregion


        public void Death()
        {
            Destroy(gameObject);
        }
    }
}