using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;
public class BurntGingerBreadAttack : MonoBehaviour
{
    public Collider2D ExplosionCollider;
    PlayerMovement player;
    public float ExplosionRange;
    public float DashRange;
    public float timeToDodge;
    public float Dashspeed;
    Rigidbody2D rb;
    bool InRange;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerMovement>();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Dash(float distance)
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
        rb.velocity = dir * Dashspeed;
        Invoke("DashReset", distance / Dashspeed);
    }

    void DashReset()
    {
        rb.velocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (Distance <= DashRange && !InRange)
        {
            InRange = true;
            Dash(Distance);
        }
        if (Distance <= ExplosionRange)
        {
            // anim de preparation a exploser
            Invoke("Explosion", timeToDodge);
        }
    }
    void Explosion()
    {
        // anim d'explosion
        ExplosionCollider.enabled = true;
        // anim de mort
        Invoke("Die",.5f);
    }
    void Die()
    {

        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, ExplosionRange);
    }
}
