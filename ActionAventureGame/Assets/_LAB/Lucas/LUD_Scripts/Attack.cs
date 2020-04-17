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
    public class Attack : MonoBehaviour
    {

        #region Variables
        #region Prefabs
        public GameObject prefabHitboxTopRight;
        public GameObject prefabHitboxTopLeft;
        public GameObject prefabHitboxBottomLeft;
        public GameObject prefabHitboxBottomRight;
        #endregion
        #region Numbers
        [Range(0.0f, 10.0f)] public float range; //portée de l'attaque
        [Range(0.0f, 100.0f)]  public float speed; //Vitesse de déplacement
        float verticalDelta; //position du joystick sur l'axe vertical
        float horizontalDelta; //position du joystick sur l'axe horizontal
        public float cooldown; //temps entre deux attaques
        public float attackDuration;//durée d'une  attaque
        int Direction;
        public int ComboCount = 0;
        float movespeed;
        float baseMoveSpeed;
        #endregion
        #region Bool
        public bool isAttacking = false; //état du joueur (attaque/attaque pas)
        public bool canAttack = true;
        #endregion
        #region Vectors
        Vector3 attackPos; //destination de l'attaque du joueur
        Vector3 attackAngle; //angle de l'attaque
        Vector3 attaqueDash;
        #endregion
        Coroutine myCoroutine;
        #endregion



        // Start is called before the first frame update
        void Start()
        {
            movespeed = GetComponent<PlayerMovement>().moveSpeed;
            baseMoveSpeed = movespeed;
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<PlayerMovement>().moveSpeed = movespeed;

            attaqueDash.x = Input.GetAxis("Horizontal");
            attaqueDash.y = Input.GetAxis("Vertical");
            #region Visée
            horizontalDelta = Input.GetAxis("Horizontal");
            verticalDelta = Input.GetAxis("Vertical");

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





            if (Input.GetButtonDown("Attack") && isAttacking==false && canAttack == true)
            {
                Attaque();
                ComboCount = 1;
            }
            else if (Input.GetButtonDown("Attack") && isAttacking == true && canAttack == true)
            {
                Attaque();
                ComboCount += 1;
                StopCoroutine(myCoroutine);
            }
            else if (isAttacking == true && ComboCount==3)
            {
                canAttack = false;
            }
        }

        void Attaque()
        {

            //Instantiate(prefabHitbox, transform.position + range * attackPos, Quaternion.Euler(transform.rotation.eulerAngles.x+attackAngle.x, transform.rotation.eulerAngles.y+attackAngle.y, transform.rotation.eulerAngles.z+attackAngle.z));
            if (Direction == 0)
            {
                prefabHitboxTopRight.SetActive(true);
            }
            else if (Direction == 1)
            {
                prefabHitboxTopLeft.SetActive(true);
            }
            else if (Direction == 2)
            {
                prefabHitboxBottomRight.SetActive(true);
            }
            else if (Direction == 3)
            {
                prefabHitboxBottomLeft.SetActive(true);
            }
            StartCoroutine(Attaque_Movement());
            myCoroutine = StartCoroutine(Attack_Cooldown());
        }
        IEnumerator Attaque_Movement()
        {
            movespeed = baseMoveSpeed*2;
            yield return new WaitForSeconds(attackDuration);
            movespeed = baseMoveSpeed;
        }
        IEnumerator Attack_Cooldown()
        {
            isAttacking = true;
            yield return new WaitForSeconds(cooldown);
            isAttacking = false;
            canAttack = true;
            Debug.Log("fhadh");
        }
    }

}
