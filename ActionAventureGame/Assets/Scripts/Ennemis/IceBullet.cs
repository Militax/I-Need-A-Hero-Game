using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Power;

namespace Ennemy
{
    public class IceBullet : MonoBehaviour
    {
        #region Variables
        public Transform player;
        public float power;
        public int damage;
        public bool isOut = false;

        Rigidbody2D rb;
        Vector2 FireDirection = new Vector2(0, 0); //Direction du tir
        Vector3 moveDirection;
        #endregion

        void Start()
        {
            FireDirection = player.position - gameObject.transform.position;
            rb = GetComponent<Rigidbody2D>();
            moveDirection = FireDirection.normalized * (power * 100) * Time.fixedDeltaTime;
        }
        void Update()
        {
            //Fait avancer la balle en fonction de (DIRECTION * FORCE)
            rb.velocity = moveDirection;
            //petite sécu
            if (rb.velocity == Vector2.zero)
            {
                moveDirection = FireDirection * (power * 100) * Time.fixedDeltaTime;
            }
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (isOut)//La balle est sortie de la collider du bonhomme de neige
            {
                if (other.CompareTag("WindWave"))
                {
                    moveDirection = ((other.GetComponentInParent<WindPower>().WaveDirection) * (power * 100) * Time.fixedDeltaTime);
                }
                else
                {
                    Destroy(gameObject);
                }
            }

            

        }
        void OnTriggerExit2D(Collider2D other)
        {
            if(!isOut)
            {
                isOut = true;
            }
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}