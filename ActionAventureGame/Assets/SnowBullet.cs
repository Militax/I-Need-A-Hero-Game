using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;
using Power;
public class SnowBullet : MonoBehaviour
{
    public bool isOut = false;
    public int damage;
    Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOut)
        {
            if (collision.CompareTag("WindWave"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce((collision.GetComponentInParent<WindPower>().WaveDirection) * (GetComponentInParent<SnowMenBehaviour>().deflectedSpeed ));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        damage = GetComponentInParent<SnowMenBehaviour>().damage;
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!isOut)
        {
            isOut = true;
        }
    }
}
