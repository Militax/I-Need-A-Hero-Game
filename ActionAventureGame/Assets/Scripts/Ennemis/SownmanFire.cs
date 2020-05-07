using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

namespace Ennemy
{
    public class SownmanFire : MonoBehaviour
    {
        Animator animator;
        #region Variables
        public PlayerMovement player;
        public GameObject iceBulletPrefab;

        public float cooldown;

        bool isInFireZone = false;
        bool canShoot = true;

        #endregion

        void Start()
        {
           animator = gameObject.GetComponent<Animator>();
        }
        void Update()
        {
            if (player == null)
            {
                player = GameManager.Instance.player;
            }

            if (isInFireZone && canShoot)
            {
                animator.SetTrigger("CanAttack");
                Shooting();
            }

            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                animator.SetFloat("Attack", 1);
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                animator.SetFloat("Attack", 0);
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                animator.SetFloat("Attack", 1);
            }
            //en haut a droite
            if (xDiff > 0 && yDiff > 0)
            {
                animator.SetFloat("Attack", 0);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInFireZone = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInFireZone = false;
            }
        }


        void Shooting()
        {
            GameObject bullet = Instantiate(iceBulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<IceBullet>().player = player.gameObject.transform;
            StartCoroutine(SnowmanFireCooldown());
        }
        IEnumerator SnowmanFireCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
    }
}