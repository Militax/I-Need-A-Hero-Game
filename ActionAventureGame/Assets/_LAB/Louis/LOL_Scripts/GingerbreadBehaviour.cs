using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackDirection
{
    NorthWest, NorthEast, SouthWest, SouthEast
}
public class GingerbreadBehaviour : Enemy
{
    public float minimumDistance;
    private bool isInAttackRange = false;
    public LayerMask playerLayerMask;

    #region attaque
    private bool canAttack = true;
    private AttackDirection attackDirection;
    [SerializeField] private GameObject NE, NW, SE, SW;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        //on set off les prefabs des colliders d'attaque
        NE.SetActive(false);
        NW.SetActive(false);
        SE.SetActive(false);
        SW.SetActive(false);
        //on set les dommages des prefabs des colliders d'attaque
        NE.GetComponent<AttackGingerbreadBehaviour>().Damage = attackDamage;
        NW.GetComponent<AttackGingerbreadBehaviour>().Damage = attackDamage;
        SE.GetComponent<AttackGingerbreadBehaviour>().Damage = attackDamage;
        SW.GetComponent<AttackGingerbreadBehaviour>().Damage = attackDamage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        DetectPlayer();
        Attack();
    }



    private void DetectPlayer()
    {
        // on regarde ou est le joueur par rapport au gingerbread
        float xDiff = player.transform.position.x - transform.position.x;
        float yDiff = player.transform.position.y - transform.position.y;
        //en bas a gauche 
        if (xDiff < 0 && yDiff < 0)
        {
            attackDirection = AttackDirection.SouthWest;
        }
        //en bas a droite
        if (xDiff > 0 && yDiff < 0)
        {
            attackDirection = AttackDirection.SouthEast;
        }
        //en haut a gauche
        if (xDiff < 0 && yDiff > 0)
        {
            attackDirection = AttackDirection.NorthWest;
        }
        //en haut a droite
        if (xDiff > 0 && yDiff > 0)
        {
            attackDirection = AttackDirection.NorthEast;
        }
    }
    private void Attack()
    {
        if (isInAttackRange == true && canAttack == true)
        {
            switch (attackDirection)
            {
                //ici on set active les colliders d'attque correspondant a la bonne position relative du joueur
                case AttackDirection.NorthEast:
                    {
                        NE.SetActive(true);
                        //Debug.Log("NE");
                        break;
                    }
                case AttackDirection.NorthWest:
                    {
                        NW.SetActive(true);
                        //Debug.Log("NW");
                        break;
                    }
                case AttackDirection.SouthEast:
                    {
                        SE.SetActive(true);
                        //Debug.Log("SE");
                        break;
                    }
                case AttackDirection.SouthWest:
                    {
                        SW.SetActive(true);
                        //Debug.Log("SW");
                        break;
                    }
                default: { break; }
            }
            canAttack = false;

            StartCoroutine("CooldownAttack");
        }

    }
    //coroutine de cooldown
    IEnumerator CooldownAttack()
    {
        //Debug.Log("willAttack");
        yield return new WaitForSecondsRealtime(3f);//attackCooldown
        canAttack = true;
        //Debug.Log("AttackCouldown");
    }

    // déplacement du gingerbread (suit le player)
    private void Move()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > minimumDistance)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
            isInAttackRange = false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            isInAttackRange = true;
        }
    }




}
