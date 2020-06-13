using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;
using Ennemy;

public class SnowMenBehaviour : MonoBehaviour
{
    #region References
    PlayerMovement Player;
    Rigidbody2D rb;
    #endregion

    #region GlobalVariables
    float distance;
    float LookingDir;
    bool LookingRight;
    bool isalive;
    #endregion

    [Header("Shoot")]
    public int damage;
    public float DetectionRange;
    public float bulletSpeed;
    public float deflectedSpeed;
    public GameObject Bullet;
    public Cooldown FireRate;
    [HideInInspector]
    public Vector2 shootDirection;
    Animator animator;

    [Header ("Push")]
    public float PushRange;
    public float pushDistance;
    public float PushSpeed;
    //public float PushDuration;
    
    Vector3 pushDirection;
    bool ispushed = false;
    public CircleCollider2D PushZone;


    [Header("Audio")]
    public AudioClip smShootAudio;

    public bool isDead;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isDead)
        {
            isalive = gameObject.GetComponent<EnemyHealth>().isAlive;
            if (Player == null)
            {
                Player = GameManager.Instance.player;
            }
            if (rb == null)
            {
                rb = Player.GetComponent<Rigidbody2D>();
            }

            distance = Vector2.Distance(Player.transform.position, transform.position);

            if (distance < DetectionRange && FireRate.IsOver())
            {
                if (isalive)
                {
                    animator.SetTrigger("Attack");
                    Shoot();
                    //LookAt();
                }

            }
            if (distance < PushRange && ispushed == false)
            {
                if (isalive)
                {
                    animator.SetBool("Repousse", true);
                    animator.SetTrigger("RepousseT");
                    ispushed = true;
                }

            }

            if (ispushed && isalive)
            {
                PushZone.radius += PushSpeed * Time.deltaTime;
                if (PushZone.radius >= pushDistance)
                {
                    PushZone.radius = 0;
                    ispushed = false;
                    animator.SetBool("Repousse", false);
                }
                //rb.velocity = pushDirection.normalized * (PushSpeed*50) * Time.deltaTime; 
            }


            float xDiff = Player.transform.position.x - transform.position.x;
            float yDiff = Player.transform.position.y - transform.position.y;
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
        
    }

    
    //IEnumerator Push()
    //{
    //    yield return new WaitForSeconds(timeBeforePushing);
    //    GameManager.Instance.playerCanMove = false;
    //    ispushed = true;
    //    Debug.LogError("hohohu");
    //    pushDirection = Player.transform.position - gameObject.transform.position;

    //    yield return new WaitForSeconds(PushDuration);

    //    ispushed = false;
    //    GameManager.Instance.playerCanMove = true;
    //}


    void Shoot()
    {
        SoundManager.instance.PlaySfx(smShootAudio, 1, 1);

        shootDirection = Player.transform.position - transform.position;

        float[] angles = { 0, -25, 25 };

        for (int i = 0; i < angles.Length; i++)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity,transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, angles[i]) * shootDirection.normalized * bulletSpeed);
            
        }

        FireRate.Reset();
    }

    //void LookAt()
    //{
    //    LookingDir = Vector2.Angle(Vector2.up, Player.transform.position);
    //    if (Player.transform.position.x > transform.position.x)
    //    {
    //        LookingRight = true;
    //    }
    //    else
    //    {
    //        LookingRight = false;
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.DrawWireSphere(transform.position, PushRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pushDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PushZone.radius);
    }
}
