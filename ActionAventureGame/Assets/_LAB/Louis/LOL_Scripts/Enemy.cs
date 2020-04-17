using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Component
    protected Rigidbody2D rb;
    protected Animator anim;
    [SerializeField]
    protected Playerdemerdenonofficiel player;

    // Health
    public float maximumHealth;
    protected float health;
    [HideInInspector] public bool isDead = false;

    // Movement
    public float baseSpeed;
    public float speedModifier = 1f;
 


    // Attack
    public float attackDamage;
    public float attackCooldown;
    public bool isAttacking = false;



    public void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maximumHealth;
    }

    
    public void OnDeathAnimation()
    {
        isDead = true;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    
}
