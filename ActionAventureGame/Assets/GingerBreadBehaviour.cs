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
    Animator animator;
    #endregion

    #region Variables

    public float stunduration;
    float distance;
    Vector2 direction;
    public GameObject ParticleSystem;
    //float LookingDir;
    //bool LookingRight;

    [HideInInspector]
    public bool ispushed;
    [HideInInspector]
    public bool isStunned;
    [HideInInspector]
    public bool isFrozen;

    public Cooldown FreezeTime;
    public float Shakeduration;
    public float ShakeAmount;
    bool isRunning;
    bool degel;
    
    Vector2 newpos;

    
    public float FreezeStunTime;
    [Header("Movement")]
    public float Speed;
    public float detectionRange;


    [Header("Attack")]
    public int damage;
    public float jumpSpeed;
    public float attackCooldown;
    public float attackRange;
    public Cooldown attackDuration;
    public float damageRange;
    bool isAttacking;
    bool isDealingDamage;
    bool missed;



    [Header("Audio")]
    public AudioClip GbDash1;
    public AudioClip GbDash2;
    public AudioClip GbDash3;
    public AudioClip GbDash4;
    public AudioClip GbDash5;

    #endregion

    public bool isDead;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>(); //parceque le gamemanager est pas encore a jour au start
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        FreezeTime.isStopped = true;
        FreezeTime.cooldownTime = FreezeStunTime;
    }
    private void Update()
    {

        
        if (FreezeTime.IsOver())
        {
            FreezeTime.isStopped = true;
            animator.SetTrigger("Idle");
            isRunning = true;
            Invoke("Degel", FreezeStunTime-1);
            Invoke("ResetFreeze", FreezeStunTime);
            
            
            StartCoroutine(ResetFreeze());
        }
        if (!isDead)
        {
            if (!isFrozen)
            {
                distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
                Vector2 dir = player.transform.position - gameObject.transform.position;

                if (distance < detectionRange && distance > attackRange && missed == false && !ispushed && !isStunned)
                {
                    animator.SetTrigger("Walk");
                    rb.velocity = dir.normalized * Speed;
                }

                if (distance < attackRange && isAttacking == false && missed == false)
                {
                    PlayGBSound();
                    animator.SetTrigger("Attack");
                    direction = player.transform.position - gameObject.transform.position;
                    isAttacking = true;
                    attackDuration.Reset();
                }

                if (isAttacking && !isDealingDamage && !ispushed && !isStunned && !attackDuration.IsOver())
                {

                    rb.velocity = direction.normalized * jumpSpeed;


                }

                //if (distance < damageRange && isAttacking == true && !isDealingDamage && !missed)
                //{
                //    GameManager.Instance.playerHealth -= damage;
                //    isDealingDamage = true;
                //    rb.velocity = Vector2.zero;
                //    Invoke("ResetAttack", attackCooldown);
                //}

                if (isAttacking && attackDuration.IsOver())
                {

                    isAttacking = false;
                    missed = true;
                    Invoke("Missed", attackCooldown);
                }

                if ((distance > detectionRange && !ispushed))
                {
                    rb.velocity = Vector2.zero;
                }

                //if (distance > attackRange && isAttacking)
                //{
                //    isAttacking = false;
                //    missed = true;
                //    Invoke("Missed", attackCooldown);
                //}
                if (missed && !ispushed)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        
        }

        float xDiff = player.transform.position.x - transform.position.x;
        float yDiff = player.transform.position.y - transform.position.y;
        //en bas a gauche 
        if (xDiff < 0 && yDiff < 0)
        {
            animator.SetFloat("Direction", 0);
        }
        //en bas a droite
        if (xDiff > 0 && yDiff < 0)
        {
            animator.SetFloat("Direction", 0.33f);
        }
        //en haut a gauche
        if (xDiff < 0 && yDiff > 0)
        {
            animator.SetFloat("Direction", 0.66f);
        }
        //en haut a droite
        if (xDiff > 0 && yDiff > 0)
        {
            animator.SetFloat("Direction", 1);
        }

    }   

    IEnumerator ResetFreeze()
    {

        yield return new WaitForSeconds(FreezeStunTime-Shakeduration);
       
        
        if (FreezeTime.isStopped)
        {
            iTween.ShakePosition(gameObject, new Vector3(ShakeAmount, 0, 0), Shakeduration);
            Debug.Log("works");
            GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);

             Destroy(fx, 1f);
             animator.SetTrigger("Idle");


            isFrozen = false;
        }
        
    }
    //void ResetFreeze()
    //{
    //    degel = false;
    //    isRunning = false;
    //    isFrozen = false;
    //    GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);

    //    Destroy(fx, 1f);
    //    animator.SetTrigger("Idle");
    //}
   

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == player.tag && isAttacking == true && !isDealingDamage && !missed && !isDead && !isFrozen && !isStunned)
        {
            if (!GameManager.Instance.invulnerability)
            {
                GameManager.Instance.playerHealth -= damage;
            }
            isDealingDamage = true;
            rb.velocity = Vector2.zero;
            GameManager.Instance.invulnerability = true;
            Invoke("ResetAttack", attackCooldown);


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, damageRange);

    }
    void PlayGBSound()
    {
        int token = Random.Range(1, 6);

        switch(token)
        {
            case (1):
                SoundManager.instance.PlaySfx(GbDash1, 1, 1);
                break;

            case (2):
                SoundManager.instance.PlaySfx(GbDash2, 1, 1);
                break;

            case (3):
                SoundManager.instance.PlaySfx(GbDash3, 1, 1);
                break;

            case (4):
                SoundManager.instance.PlaySfx(GbDash4, 1, 1);
                break;

            case (5):
                SoundManager.instance.PlaySfx(GbDash5, 1, 1);
                break;

        }
    }
}
