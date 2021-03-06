﻿using System.Collections;
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
        [SerializeField]
        private SwichGlobal switch1, switch2;
        public bool canDestroyBox = false;
        /*
         0 : Idle
         3 : Feu
         2 : Eau
         1 : Lumière
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
        bool bouncefire = true;
        bool firephase2 = false;
        #endregion
        #region EAU
        public GameObject waterProps;
        public List<GameObject> waterList;

        public GameObject SnowManPrefab;
        public List<Transform> Spawners;
        public Transform WaterRespawn;
        List<GameObject> SnowManList = new List<GameObject>();
        bool canSpawnSnowman = true;
       
        #endregion
        #region LUMIERE
        public GameObject lightprops;
        public GameObject shieldPrefab;
        public GameObject lightBulletPrefab;
        public Transform shieldSpawn;
        public float lightFireCooldown;
        bool bouncelight = true;

        int shieldLife = 4;
        float stuntTime = 4;
        public bool shieldActive = false;
        public bool isStunt = false;
        bool isInLightCoroutine = false;

        bool canShootLight = true;
        #endregion

        public Transform centerRespawn;
        public Transform fireRespawn;
        public Transform fireRespawn2;

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
            if (CurrentPhase == 3)
            {

                if (this.GetComponent<BossHealth>().CurrentBossLife == 2 && firephase2 == false)
                {
                    player.transform.position = fireRespawn2.position;
                    canDestroyBox = true;
                    firephase2 = true;
                }
            }
            if (CurrentPhase == 1)
            {
                if (this.GetComponent<BossHealth>().CurrentBossLife == 13 && bouncelight == true)
                {
                    player.transform.position = fireRespawn.position;
                    ChangeSwitchLightState(false);
                    bouncelight = false;
                }
            }

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
                case (3):
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

                case (1):
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

        //void BoxSpawn()
        //{
        //    foreach (Transform spawn in boxSpawners)
        //    {
        //        GameObject Box = Instantiate(heavyBoxPrefab, spawn.position, spawn.rotation, fireProps.transform);
        //        boxsList.Add(Box);
        //    }
        //}

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
            if (isStunt && !isInLightCoroutine)
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

            CurrentPhase++;
            Debug.Log(CurrentPhase);
            if (CurrentPhase == 2)
            {
                player.transform.position = WaterRespawn.position;
            }
            if (CurrentPhase == 1)
            {
                player.transform.position = centerRespawn.position;
            }
            if (CurrentPhase == 3)
            {
                player.transform.position = fireRespawn.position;
            }
            GetComponent<BossHealth>().haveToChange = false;
        }
        void ChangeSwitchLightState(bool newState)
        {
            //switch1.IsActive = newState;
            //switch2.IsActive = newState;
            GameObject switcher1 = Instantiate(lightBulletPrefab, switch1.gameObject.transform);
            GameObject switcher2 = Instantiate(lightBulletPrefab, switch2.gameObject.transform);
            //switcher1.tag = "LightBullet"; switcher2.tag = "LightBullet";
            //BoxCollider2D col1 = switcher1.AddComponent<BoxCollider2D>();
            //BoxCollider2D col2 = switcher2.AddComponent<BoxCollider2D>();
            //col1.size = Vector2.one; col2.size = Vector2.one;
            StartCoroutine("DestroyAfterSeconds", switcher1);
            StartCoroutine("DestroyAfterSeconds", switcher2);
        }
        IEnumerator DestroyAfterSeconds(GameObject gameObject)
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
        void PhasePropsManagement()//Gère l'apparition des objets nécessaire à chaque phases.
        {
            switch (CurrentPhase)
            {
                case (3):
                    if (bouncefire)
                    {
                        player.transform.position = fireRespawn.position;
                        bouncefire = false;
                    }

                    if (lightprops.activeSelf)
                    {
                        lightprops.SetActive(false);
                    }
                    if (waterProps.activeSelf)
                    {
                        waterProps.SetActive(false);
                    }
                    if (!fireProps.activeSelf)
                    {
                        fireProps.SetActive(true);
                    }


                    if (!canSpawnSnowman)
                    {
                        canSpawnSnowman = true;
                    }


                    if (SnowManList.Count > 0)
                    {
                        ClearList(SnowManList);
                    }
                    break;

                case (2):
                    if (lightprops.activeSelf)
                    {
                        lightprops.SetActive(false);
                    }
                    if (!waterProps.activeSelf)
                    {
                        waterProps.SetActive(true);
                    }
                    if (fireProps.activeSelf)
                    {
                        fireProps.SetActive(false);
                    }

                    if (!canSpawnBoxs)
                    {
                        canSpawnBoxs = true;
                    }


                    if (boxsList.Count > 0)
                    {
                        ClearList(boxsList);
                    }
                    break;


                case (1):
                    if (!lightprops.activeSelf)
                    {
                        lightprops.SetActive(true);
                    }
                    if (waterProps.activeSelf)
                    {
                        waterProps.SetActive(false);
                    }
                    if (fireProps.activeSelf)
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
                    lightprops.SetActive(false);
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

        void ClearList(List<GameObject> _list)
        {
            foreach (GameObject item in _list)
            {
                Destroy(item);
            }

            _list.Clear();
        }
    }
}