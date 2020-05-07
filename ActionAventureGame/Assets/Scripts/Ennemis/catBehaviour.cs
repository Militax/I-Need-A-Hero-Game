using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

public class catBehaviour : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float prepareTime;
    float speed;
    public float dashTime;
    public float vulnerable;
    public bool canBeDamaged;
    bool playerisIn = false;
    bool prepare;
    public float detectionRange;
    public PlayerMovement Player;
    Vector3 target;
    int direction;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    IEnumerator Preparing()
    {
        while (playerisIn)
        {
            if (prepare)
            {
                yield return new WaitForSeconds(prepareTime / 2);
                animator.SetTrigger("Preparation");
                
                prepare = false;
            }
            target = Player.transform.position;
            yield return new WaitForSeconds(prepareTime / 2);
            
            Dash();
            yield return new WaitForSeconds(dashTime);
            
            
            rb.velocity = Vector3.zero;
            canBeDamaged = true;
            yield return new WaitForSeconds(vulnerable);
            
            canBeDamaged = false;


            prepare = true;

        }
        
        
    }




    private void Update()
    {
        if (Player == null)
        {
            Player = GameManager.Instance.player;
        }

        bool activation = playerisIn;

        playerisIn = (Vector3.Distance(transform.position, Player.transform.position) <= detectionRange);
        
        if (activation != playerisIn && playerisIn)
        {
            prepare = true;
            StartCoroutine(Preparing());
        }
        if (rb.velocity == Vector2.zero)
        {
            Vector3 path = (Player.transform.position - gameObject.transform.position).normalized;
            animator.SetFloat("Direction", Vector2.Angle(transform.up, path));
        }

    }

    void Dash()
    {
        Vector3 path = (target - gameObject.transform.position).normalized;
        animator.SetTrigger("CanAttack");
        animator.SetFloat("Attack", Vector2.Angle(transform.up, path));
        float distance = Vector3.Distance(transform.position, target);
        speed = distance / dashTime;
        rb.velocity = path * speed;
        animator.SetFloat("Direction", Vector2.Angle(transform.up, path));
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange/3 *2);
    }
}
