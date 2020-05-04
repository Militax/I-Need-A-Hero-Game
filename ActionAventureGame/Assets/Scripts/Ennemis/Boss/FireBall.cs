using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Boss
{
    public class FireBall : MonoBehaviour
    {
        #region Variables
        public int damage;
        public float speed;
        public float lifeTime;

        public Vector2 direction;
        Rigidbody2D rb;
        #endregion

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            StartCoroutine(LifeTime());
            rb.velocity = direction * speed;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Box"))
            {
                Destroy(gameObject);
            }
            else if (other.CompareTag("Player"))
            {
                GameManager.Instance.playerHealth -= damage;
                Destroy(gameObject);
            }
        }

        IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}