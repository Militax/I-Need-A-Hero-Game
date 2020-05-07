using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Power;
using GameManagement;

public class Bullet : MonoBehaviour
{
    public int damages;

    [HideInInspector]
    public float bulletSpeed;
    public Vector2 bulletDirection;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = bulletDirection * (bulletSpeed*100) * Time.fixedDeltaTime;
    }
    private void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            rb.velocity = bulletDirection * (bulletSpeed*100) * Time.fixedDeltaTime;
        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WindWave"))
        {
            rb.velocity = other.GetComponentInParent<WindPower>().WaveDirection * (bulletSpeed*100) * Time.fixedDeltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
