using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

public class GingerBreadBehaviour : MonoBehaviour
{
    #region References
    PlayerMovement player;
    Rigidbody2D rb;
    #endregion

    #region Variables

    float distance;
    Vector2 direction;
    [HideInInspector]
    public bool ispushed;
    [HideInInspector]
    public bool isFrozen;

    
    bool isRunning;

    
    public float FreezeStunTime;
    [Header("Movement")]
    public float Speed;
    public float detectionRange;


    [Header("Attack")]
    public int damage;
    public float jumpSpeed;
    public float attackCooldown;
    public float attackRange;
    
    public float damageRange;
    bool isAttacking;
    bool isDealingDamage;
    bool missed;
    
    #endregion



    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>(); //parceque le gamemanager est pas encore a jour au start
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        

        if (isFrozen && !isRunning)
        {
            //anim gel
            isRunning = true;
            Invoke("ResetFreeze", FreezeStunTime);
        }
        if ( !isFrozen)
        {
            distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            Vector2 dir = player.transform.position - gameObject.transform.position;

            if (distance < detectionRange && distance > attackRange && missed == false)
            {
                rb.velocity = dir.normalized * Speed;
            }

            if (distance < attackRange && isAttacking == false && missed == false)
            {

                direction = player.transform.position - gameObject.transform.position;
                isAttacking = true;
            }

            if (isAttacking && !isDealingDamage &&!ispushed)
            {

                rb.velocity = direction.normalized * jumpSpeed;


            }

            if (distance < damageRange && isAttacking == true && !isDealingDamage && !missed)
            {
                GameManager.Instance.playerHealth -= damage;
                isDealingDamage = true;
                rb.velocity = Vector2.zero;
                Invoke("ResetAttack", attackCooldown);
            }

            if (distance > detectionRange && !ispushed)
            {
                rb.velocity = Vector2.zero;
            }

            if (distance > attackRange && isAttacking)
            {
                isAttacking = false;
                missed = true;
                Invoke("Missed", attackCooldown);
            }
            if (missed && !ispushed)
            {
                rb.velocity = Vector2.zero;
            }
        }
        
    }
    void ResetFreeze()
    {
        isRunning = false;
        isFrozen = false;
    }
   

    void Missed()
    {
        missed = false;
    }
    
    private void ResetAttack()
    {
        isDealingDamage = false;
        isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAttacking)
        {
            
            rb.velocity = Vector2.zero;
            isAttacking = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, damageRange);

    }
}
