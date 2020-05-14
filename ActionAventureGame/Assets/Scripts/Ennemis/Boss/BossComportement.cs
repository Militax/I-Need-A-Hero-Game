using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

namespace Boss
{
    public class BossComportement : MonoBehaviour
    {
        #region Variables
        public PlayerMovement player;
        public int CurrentPhase = 0;
        public int numberOfPhases;
        
        /*
         0 : Idle
         1 : Feu
         2 : Eau
         3 : Lumière
         */

        #region FEU
        public GameObject fireProps;
        public List<Transform> boxSpawners;
        List<GameObject> boxsList = new List<GameObject>();

        public GameObject heavyBoxPrefab;
        public int bulletNumber;
        public float fireWaveCooldown;
        bool canSpawnBoxs = true;
        bool canShootWave = true;
        bool playerIsPuch = false;
        #endregion
        #region EAU
        public GameObject waterProps;
        public List<GameObject> waterList;

        public GameObject SnowManPrefab;
        public List<Transform> Spawners;
        List<GameObject> SnowManList = new List<GameObject>();
        bool canSpawnSnowman = true;
        #endregion
        #region LUMIERE
        public GameObject shieldPrefab;
        public GameObject lightBulletPrefab;
        public Transform shieldSpawn;
        public float lightFireCooldown;

        int shieldLife = 4;
        float stuntTime = 4;
        public bool shieldActive = false;
        public bool isStunt = false;
        bool isInLightCoroutine = false;

        bool canShootLight = true;
        #endregion

        public Transform centerRespawn;

        public Transform shootPoint;
        public GameObject fireBallPrefab;
        public Animator animator;


        #endregion

        void Start()
        {
            SelectNewPhase();
        }
        void Update()
        {


            if (player == null)
            {
                player = GameManager.Instance.player;
            }

            PhasePropsManagement();
            if (GetComponent<BossHealth>().haveToChange == true)
            {
                //animator.SetTrigger("Change"); 
                SelectNewPhase();
            }

            switch (CurrentPhase)
            {
                case (1):
                    animator.SetTrigger("Feu_Spawn");
                    animator.SetBool("Feu", true);
                    animator.SetBool("Eau", false);
                    animator.SetBool("Lum", false);
                    if (canShootWave)
                    {
                        FireAttack();
                        animator.SetTrigger("Attack");
                    }

                    if (canSpawnBoxs)
                    {
                        BoxSpawn();
                        canSpawnBoxs = false;
                    }
                    break;

                case (2):
                    animator.SetTrigger("Eau_Spawn");
                    animator.SetBool("Feu", false);
                    animator.SetBool("Eau", true);
                    animator.SetBool("Lum", false);

                    if (canSpawnSnowman)
                    {
                        spawnSnowMan();
                        canSpawnSnowman = false;
                    }
                    break;

                case (3):
                    animator.SetTrigger("Lum_Spawn");
                    animator.SetBool("Feu", false);
                    animator.SetBool("Eau", false);
                    animator.SetBool("Lum", true);
                    LightAttack();
                    
                    break;

                default:
                    break;
                
            }    
        }



        #region FIRE ATTACK
        void FireAttack()
        {
            FireWave();
            StartCoroutine(FireWaveCooldown());
        }

        void BoxSpawn()
        {
            foreach (Transform spawn in boxSpawners)
            {
                GameObject Box = Instantiate(heavyBoxPrefab, spawn.position, spawn.rotation, fireProps.transform);
                boxsList.Add(Box);
            }
        }

        //Instancie la vague de boule de feu
        void FireWave()
        {
            //87 paarce que sinon c'est pas droit la vague
            float rotation = -90;
            float angleStep = 180f / bulletNumber;

            //Créer toute les balles
            for (int i = 0; i < bulletNumber; i++)
            {
                //Je sais pas à quoi ca sert, ca vient d'Acocalypse
                float bulletDirXposition = shootPoint.position.x + Mathf.Sin((rotation * Mathf.PI) / 180) * 5f;
                float bulletDirYposition = shootPoint.position.y + Mathf.Cos((rotation * Mathf.PI) / 180) * 5f;

                //création de la balle et de son orientation
                GameObject fireBall = Instantiate(fireBallPrefab, shootPoint.position, Quaternion.identity);
                fireBall.transform.Rotate(new Vector3(0, 0, rotation));

                //On assigne la bonne valeur au vecteur direction de la balle
                float speed = fireBall.GetComponent<FireBall>().speed;
                Vector3 bulletVector = new Vector3(bulletDirXposition, bulletDirYposition, 0);
                Vector2 bulletMoveDirection = (bulletVector - shootPoint.position).normalized * speed;
                fireBall.GetComponent<FireBall>().direction = new Vector2(bulletMoveDirection.x, -(bulletMoveDirection.y));

                //On augmente l'angle pour la prochaine balle
                rotation += angleStep;
            }
        }

        IEnumerator FireWaveCooldown()
        {
            canShootWave = false;
            yield return new WaitForSeconds(fireWaveCooldown);
            canShootWave = true;
        }
        #endregion
        #region WATER ATTACK

        void spawnSnowMan()
        {
            foreach (Transform spawn in Spawners)
            {
                GameObject SnowMan = Instantiate(SnowManPrefab, spawn.position, spawn.rotation, waterProps.transform);
                SnowManList.Add(SnowMan);
            }
        }

        #endregion
        #region LIGHT ATTACK
        void LightAttack()
        {
            animator.SetTrigger("Attack");

            if (!shieldActive && !isStunt)
            {
                createBossShield();
            }
            if(isStunt && !isInLightCoroutine)
            {
                StartCoroutine(bossStunt());
            }
            if (!isStunt)
            {
                if (canShootLight)
                {
                    StartCoroutine(lightFire());
                }
            }
        }
        void createBossShield()
        {
            if ((player.transform.position.y >= (transform.position.y - 10)) && (player.transform.position.x >= transform.position.x - 10) && (player.transform.position.x <= transform.position.x + 10))
            {
                if (!playerIsPuch)
                {
                    StartCoroutine(playerPush());
                }
            }
            else
            {
                GameObject shield = Instantiate(shieldPrefab, shieldSpawn.position, shieldSpawn.rotation, transform);
                shieldActive = true;
            }
        }
        IEnumerator bossStunt()
        {
            isInLightCoroutine = true;
            yield return new WaitForSeconds(stuntTime);
            isInLightCoroutine = false;
            isStunt = false;
        }
        IEnumerator lightFire()
        {
            canShootLight = false;
            GameObject lighBullet = Instantiate(lightBulletPrefab, shootPoint.position, shootPoint.rotation);
            yield return new WaitForSeconds(lightFireCooldown);
            canShootLight = true;
        }

        #endregion

        IEnumerator playerPush()
        {
            playerIsPuch = true;
            GameManager.Instance.playerCanMove = false;

            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

            yield return new WaitForSeconds(0.5f);

            GameObject shield = Instantiate(shieldPrefab, shieldSpawn.position, shieldSpawn.rotation, transform);

            shieldActive = true;
            GameManager.Instance.playerCanMove = true;
            playerIsPuch = false;
        }

        void SelectNewPhase()
        {
            int futurPhase;
            futurPhase = Random.Range(1, 4);

            while (futurPhase == CurrentPhase)
            {
                futurPhase = Random.Range(1, 4);
            }
            CurrentPhase = futurPhase;
            player.transform.position = centerRespawn.position;

            GetComponent<BossHealth>().haveToChange = false;
        }
        void PhasePropsManagement()//Gère l'apparition des objets nécessaire à chaque phases.
        {
            switch (CurrentPhase)
            {
                case (1):
                    
                    if (fireProps.activeSelf == false)
                    {
                        fireProps.SetActive(true);
                    }
                    if (waterProps.activeSelf == true)
                    {
                        waterProps.SetActive(false);
                    }


                    if (canSpawnSnowman == false)
                    {
                        canSpawnSnowman = true;
                    }


                    if (SnowManList.Count > 0)
                    {
                        ClearList(SnowManList);
                    }
                    break;

                case (2):

                    if (waterProps.activeSelf == false)
                    {
                        waterProps.SetActive(true);
                    }
                    if (fireProps.activeSelf == true)
                    {
                        fireProps.SetActive(false);
                    }

                    if (canSpawnBoxs == false)
                    {
                        canSpawnBoxs = true;
                    }


                    if (boxsList.Count > 0)
                    {
                        ClearList(boxsList);
                    }
                    break;


                case (3):


                    if (waterProps.activeSelf == true)
                    {
                        waterProps.SetActive(false);
                    }
                    if (fireProps.activeSelf == true)
                    {
                        fireProps.SetActive(false);
                    }


                    if (canSpawnSnowman == false)
                    {
                        canSpawnSnowman = true;
                    }
                    if (canSpawnBoxs == false)
                    {
                        canSpawnBoxs = true;
                    }


                    if (SnowManList.Count > 0)
                    {
                        ClearList(SnowManList);
                    }
                    if (boxsList.Count > 0)
                    {
                        ClearList(boxsList);
                    }
                    break;


                default:
                    fireProps.SetActive(false);
                    waterProps.SetActive(false);

                    if (canSpawnSnowman == false)
                    {
                        canSpawnSnowman = true;
                    }
                    if (canSpawnBoxs == false)
                    {
                        canSpawnBoxs = true;
                    }



                    if (SnowManList.Count > 0)
                    {
                        ClearList(SnowManList);
                    }
                    if (boxsList.Count > 0)
                    {
                        ClearList(boxsList);
                    }
                    break;

            }
        }

        void ClearList (List<GameObject> _list)
        {
            foreach (GameObject item in _list)
            {
                Destroy(item);
            }

            _list.Clear();
        }
    }
}