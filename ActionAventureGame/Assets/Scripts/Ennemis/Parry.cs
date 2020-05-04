using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    Rigidbody2D rb;
    bool takedamage;
    Animator animator;
    
    // Start is called before the first frame update

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        takedamage = gameObject.GetComponent<catBehaviour>().canBeDamaged;
        animator = gameObject.GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword")
        {
            if (takedamage)
            {
                gameObject.GetComponent<CatHp>().currentHP -= gameObject.GetComponent<CatHp>().DamageTaken;
                animator.SetTrigger("Degat");
            }
            else
                animator.SetTrigger("Parade");
                return; //animation parade


        }
        if (collision.tag == "WindWave")
        {
            rb.velocity = Vector3.zero;
        }

    }
}
