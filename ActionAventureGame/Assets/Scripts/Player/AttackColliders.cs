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
        

        public void deactivate()
        {
            
            gameObject.transform.localScale = Vector3.zero;
        }
    }
}