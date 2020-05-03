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
        /*
         1 : Feu
         2 : Eau
         3 : Lumière
         */

        #region FEU
        public int bulletNumber;
        public float fireWaveCooldown;
        bool canShootWave = true;
        bool playerIsPuch = false;
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

        public Transform shootPoint;
        public GameObject fireBallPrefab;
        public Animator animator;


        #endregion



        void Update()
        {
            if (player == null)
            {
                player = GameManager.Instance.player;
            }


            switch (CurrentPhase)
            {
                case (1):
                    animator.SetTrigger("Feu_Spawn");
                    if (canShootWave)
                    {
                        FireAttack();
                        animator.SetTrigger("Feu_Attack");
                    }
                    break;

                case (2):
                    animator.SetTrigger("Eau_Spawn");
                    break;

                case (3):
                    animator.SetTrigger("Lum_Spawn");
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



        #region LIGHT ATTACK
        void LightAttack()
        {
            animator.SetTrigger("Lum_Attack");
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

        #endregion
    }
}