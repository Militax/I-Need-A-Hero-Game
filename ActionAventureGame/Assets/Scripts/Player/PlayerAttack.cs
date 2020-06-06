using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


/// <summary>
/// Lucas Deutschmann
/// 
/// Script attaque joueur
/// </summary>
namespace Player
{

    /// <summary>
    /// Lucas Deutschmann
    /// 
    /// Script attaque joueur
    /// </summary>
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables
        #region Prefabs
        public GameObject prefabHitboxTopRight;
        public GameObject prefabHitboxTopLeft;
        public GameObject prefabHitboxBottomLeft;
        public GameObject prefabHitboxBottomRight;
        public GameObject SlamHitbox;
        #endregion
        #region Numbers
        
        [Range(0.0f, 2f)] public float speed; //Vitesse de déplacement
        float verticalDelta; //position du joystick sur l'axe vertical
        float horizontalDelta; //position du joystick sur l'axe horizontal
        public float cooldown; //temps entre deux attaques
        public int Direction;
        public int ComboCount = 0;
        float movespeed;
        [HideInInspector]
        public float baseMoveSpeed;
        public float attackDuration;//durée d'une  attaque
        #endregion
        #region Bool
        public bool isAttacking = false; //état du joueur (attaque/attaque pas)
        public bool canAttack = true;
        #endregion
        #region Vectors
        Vector3 attackPos; //destination de l'attaque du joueur
        Vector3 attackAngle; //angle de l'attaque
        Vector3 attaqueDash;
        public Vector3 attackScale;
        
        #endregion
        public Animator animator;
        
        Cooldown myCD;
        Cooldown myAtkSpeed;
        public float attackSpeed;
        #endregion


		[Header("Sound")]
		public AudioClip attaque1;

		

        private void Start()
        {
            myAtkSpeed = new Cooldown(attackSpeed);
            myCD = new Cooldown(cooldown);
            movespeed = GetComponent<PlayerMovement>().moveSpeed;
            baseMoveSpeed = movespeed;
        }
        void Update()
        {
            
            

            AttaqueAIM();

            canAttack = myAtkSpeed.IsOver();
            isAttacking = !myCD.IsOver();
            if (Input.GetButtonDown("Attack") && isAttacking == false && canAttack == true)
            {
                
                ComboCount = 1;
                
                Attaque();
				
            }
            else if (Input.GetButtonDown("Attack") && isAttacking == true && canAttack == true)
            {
                
                ComboCount += 1;
                
                Attaque();
				
                
            }
            //else if (isAttacking == true && ComboCount == 3)
            //{
            //    canAttack = false;
                
            //}
        }

        void Attaque()
        {
            //Debug.Log("attaaaa");
            animator.SetInteger("NumAttack", ComboCount);

            if (ComboCount<3)
            {
                if (Direction == 0)
                {
                    prefabHitboxTopRight.transform.localScale = attackScale;
                    
                    prefabHitboxTopRight.GetComponent<AttackColliders>().Invoke("deactivate", attackDuration);
					
                }
                else if (Direction == 1)
                {
                    prefabHitboxTopLeft.transform.localScale = attackScale;
                    
                    prefabHitboxTopLeft.GetComponent<AttackColliders>().Invoke("deactivate", attackDuration);

                }
                else if (Direction == 2)
                {
                    prefabHitboxBottomRight.transform.localScale = attackScale;
                    
                    prefabHitboxBottomRight.GetComponent<AttackColliders>().Invoke("deactivate", attackDuration);
                }
                else if (Direction == 3)
                {
                    prefabHitboxBottomLeft.transform.localScale = attackScale;
                    
                    prefabHitboxBottomLeft.GetComponent<AttackColliders>().Invoke("deactivate", attackDuration);
                }
                myAtkSpeed.Reset();
                myCD.Reset();
                
				SoundManager.instance.PlaySfx(attaque1, 1, 1);
                StartCoroutine(Attaque_Movement());
            }
            else if (ComboCount == 3)
            {
                
                Invoke("Slam",.5f);
                StartCoroutine(Attaque_Movement());
            }           
            
            
        }
        void Slam()
        {
            GameObject slam = Instantiate(SlamHitbox, transform.position, Quaternion.identity);

            slam.GetComponent<CircleCollider2D>().radius += .1f;
            SlamHitbox.GetComponent<AttackColliders>().Invoke("deSpawn", attackDuration);
            myCD.Reset();
            myAtkSpeed.Reset();
        }
        IEnumerator Attaque_Movement()
        {
            movespeed = baseMoveSpeed * speed;
            GetComponent<PlayerMovement>().moveSpeed = movespeed;
            yield return new WaitForSeconds(attackDuration);
            animator.SetInteger("NumAttack", 0);
            movespeed = baseMoveSpeed;
            GetComponent<PlayerMovement>().moveSpeed = movespeed;
        }
        void AttaqueAIM()
        {
            attaqueDash.x = Input.GetAxis("Horizontal");
            attaqueDash.y = Input.GetAxis("Vertical");
            #region Visée
            horizontalDelta = Input.GetAxis("Horizontal");
            verticalDelta = Input.GetAxis("Vertical");

            animator.SetFloat("Horizontal", horizontalDelta);
            animator.SetFloat("Vertical", verticalDelta);

            if (verticalDelta > 0.2 || horizontalDelta > 0.2 || verticalDelta < -0.2 || horizontalDelta < -0.2)
            {
                //verifie que le joystick est vraiment utilisé de manière volontaire
                if (verticalDelta >= 0 && horizontalDelta >= 0)
                {
                    // regarde en haut à droite
                    //attackPos = (transform.position + transform.up + transform.right).normalized;
                    //attackAngle = new Vector3(0, 0, 180);
                    Direction = 0;
                }
                if (verticalDelta >= 0 && horizontalDelta <= 0)
                {
                    // regarde en haut à gauche

                    Direction = 1;
                }
                if (verticalDelta <= 0 && horizontalDelta >= 0)
                {
                    // regarde en bas à droite

                    Direction = 2;
                }
                if (verticalDelta <= 0 && horizontalDelta <= 0)
                {
                    // regarde en bas à gauche

                    Direction = 3;
                }
            }

            #endregion
        }


        //void Attack_Cooldown()
        //{
        //    isAttacking = true;
        //    yield return new WaitForSeconds(cooldown);
        //    isAttacking = false;
        //    canAttack = true;
        //}
    }

}