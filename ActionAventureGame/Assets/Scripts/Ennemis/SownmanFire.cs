using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ennemy
{
    public class SownmanFire : MonoBehaviour
    {
        Animator animator;
        #region Variables
        public Transform player;
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
            if (isInFireZone && canShoot)
            {
                Shooting();
                animator.SetTrigger("CanAttack");
            }

            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                animator.SetFloat("Attack", 0.5f);
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                animator.SetFloat("Attack", 0);
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                animator.SetFloat("Attack", 0.5f);
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
            bullet.GetComponent<IceBullet>().player = player;
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