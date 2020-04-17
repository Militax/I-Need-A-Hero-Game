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
        Animator animator;

        void Start()
        {
            FireDirection = player.position - gameObject.transform.position;
            rb = GetComponent<Rigidbody2D>();
            moveDirection = FireDirection.normalized * (power * 100) * Time.fixedDeltaTime;
            animator = gameObject.GetComponent<Animator>();
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

            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                animator.SetFloat("Attack",0.5f);
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                animator.SetFloat("Attack",0);
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                animator.SetFloat("Attack",0.5f);
            }
            //en haut a droite
            if (xDiff > 0 && yDiff > 0)
            {
                animator.SetFloat("Attack",0);
            }
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && isOut)
            {
                GameManager.Instance.playerHealth -= damage;
                animator.SetTrigger("Hit");
                Destroy(gameObject);
            }
            if (other.CompareTag("WindWave") && isOut)
            {
                moveDirection = ((other.GetComponent<WindPower>().WaveDirection) * (power * 100) * Time.fixedDeltaTime);
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