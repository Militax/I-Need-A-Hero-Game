using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Power;
using GameManagement;
using Player;

namespace Boss
{
    public class LightBall : MonoBehaviour
    {
        #region Variables
        public PlayerMovement player;
        public float power;
        public int damage;
        public bool isOut = false;

        Rigidbody2D rb;
        Vector2 FireDirection = new Vector2(0, 0); //Direction du tir
        Vector3 moveDirection;
        #endregion


        void Start()
        {
            player = GameManager.Instance.player;
            FireDirection = player.transform.position - gameObject.transform.position;
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
            if (other.CompareTag("Player") && isOut)
            {
                GameManager.Instance.playerHealth -= damage;
                Destroy(gameObject);
            }
            if (other.CompareTag("WindWave") && isOut)
            {
                moveDirection = ((other.GetComponent<WindPower>().WaveDirection) * (power * 100) * Time.fixedDeltaTime);
            }
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}