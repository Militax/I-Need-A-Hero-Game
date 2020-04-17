using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Objet qui bouge après avoir recu du vent
    /// </summary>
    public class MovableObject : MonoBehaviour
    {
        public int powerStateRequest;

        public float duration;
        public float slowdown;

        Rigidbody2D rb;
        public bool isMoving;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isMoving = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave") && !isMoving && GameManager.Instance.powerState >= powerStateRequest)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = other.GetComponentInParent<Rigidbody2D>().velocity / slowdown;
                StartCoroutine(moveDuration());
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Player")
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

            }
            
        }



        IEnumerator moveDuration()
        {
            isMoving = true;
            yield return new WaitForSeconds(duration);
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}