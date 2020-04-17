using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Représente l'évolution de la vague dans le temps et sur une distance établie
    /// </summary>
    public class WindPower : MonoBehaviour
    {

        #region Variables
        public float duration;
        public float power;
        public float YPerFrame;
        
        Vector3 ScaleChange;

        Rigidbody2D rb;
        public Vector2 WaveDirection = new Vector2(0,0); //Direction du tir
        #endregion
        
        void Start()
        {//Quand l'objet s'instanci
            rb = GetComponent<Rigidbody2D>();       
            StartCoroutine(PowerDuration());
            ScaleChange.Set(0, (YPerFrame/1000), 0);
        }

        private void Update()
        {            
            //Fait avancer la vague en fonction de (DIRECTION * FORCE)
            rb.velocity = WaveDirection * (power*100) * Time.fixedDeltaTime;
            transform.localScale += ScaleChange;
        }


        //Durée de vie de la vague
        IEnumerator PowerDuration()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}