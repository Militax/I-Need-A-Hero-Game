using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Ennemy;
using GameManagement;

public class CatBehaviourProto : MonoBehaviour
{
    #region References
    PlayerMovement player;
    Rigidbody2D rb;
    Rigidbody2D PlayeRb;
    bool takedamage = false;

    #endregion
    Animator animator;


    #region Variables
    Vector2 dir;
    float distance;
    Vector2 direction;
    float LookingDir;
    bool LookingRight;

    [HideInInspector]
    public bool isPushed;
    public float cdCape;

    [Header("Movement")]
    public float speed;
    public float detectionRange;

    [Header("Attack")]
    public int Damage;
    public float AttackRange;
    public float attackForce;
    bool isAttacking;
    public float attackDuration;
    public float timeBeforeAttack;
    public float attackCoolDown;



    [Header("Audio")]
    public AudioClip CatDrappedAudio;
    public AudioClip CatAttackAudio1;
    public AudioClip CatAttackAudio2;
    public AudioClip CatAttackAudio3;
    public AudioClip CatAttackAudio4;
    public AudioClip CatAttackAudio5;


    #endregion

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        PlayeRb = player.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - gameObject.transform.position;
        distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance < detectionRange && distance > AttackRange && !isPushed)
        {
            animator.SetTrigger("Walk");
            rb.velocity = dir.normalized * speed;
        }

        if (distance <= AttackRange && isAttacking == false && !isPushed)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            rb.velocity = Vector2.zero;
            direction = player.transform.position - gameObject.transform.position;
            print("attack");
            Invoke("Attack", timeBeforeAttack);
        }

        if (distance >= detectionRange)
        {
            rb.velocity = Vector2.zero;
        }

        if (isPushed)
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WindWave" &&isPushed == false)
        {
            Debug.Log("hihi");
            Cape();
        }
    }

    void Attack()
    {

        GameManager.Instance.playerHealth -= Damage;
        iTween.MoveAdd(player.gameObject, direction.normalized * attackForce, attackDuration);
        PlayAttackSound();
        Invoke("AttackCD", attackCoolDown);
    }

    void AttackCD()
    {
        isAttacking = false;
    }
    void Cape()
    {
        //takedamage = true;
        SoundManager.instance.PlaySfx(CatDrappedAudio, 1, 1);
        animator.SetTrigger("Etourdi");
        isPushed = true;
        Invoke("BecomeVulnerable", cdCape);


    }

    void BecomeVulnerable()
    {
        isPushed = false;
        animator.SetTrigger("Idle");
        //takedamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        iTween.Stop();
    }

    void LookAt()
    {
        LookingDir = Vector2.Angle(Vector2.up, player.transform.position);
        if (player.transform.position.x > transform.position.x)
        {
            LookingRight = true;
        }
        else
        {
            LookingRight = false;
        }
    }





    void PlayAttackSound()
    {
        int token = Random.Range(1, 6);

        switch(token)
        {
            case (1):
                SoundManager.instance.PlaySfx(CatAttackAudio1, 1, 1);
                break;

            case (2):
                SoundManager.instance.PlaySfx(CatAttackAudio2, 1, 1);
                break;

            case (3):
                SoundManager.instance.PlaySfx(CatAttackAudio3, 1, 1);
                break;

            case (4):
                SoundManager.instance.PlaySfx(CatAttackAudio4, 1, 1);
                break;

            case (5):
                SoundManager.instance.PlaySfx(CatAttackAudio5, 1, 1);
                break;
        }
    }
}
