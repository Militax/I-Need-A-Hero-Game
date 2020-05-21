using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Power;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Script qui gère l'envoie du vent par un générateur
    /// </summary>
    public class WindGenerator : MonoBehaviour
    {

        Animator animator;
        #region Variables
        public ActivationDevice Input;
        public string direction;
        public float waveDuration;
        public float wavePower;

        public GameObject windPowerPrefab;
        public Transform shootPoint;
        public float timeBetweenWave;

        bool canShoot;
        #endregion

        private void Start()
        {
            canShoot = true;
            animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.IsActive)
            {
                WaveFire();
                animator.SetTrigger("Generate");
            }

            else if (!Input.IsActive)
            {
                animator.SetTrigger("Stop");
            }

        }

            //Instancie le tir
            void WaveFire()
        {
            
            if (canShoot)
            {
                GameObject WindWave = Instantiate(windPowerPrefab, shootPoint.position, shootPoint.rotation);
                //Modifie les valeurs de la vague
                WindWave.GetComponent<WindPower>().duration = waveDuration;
                WindWave.GetComponent<WindPower>().power = wavePower;

                //Donne la direction
                switch (direction)
                {
                    case ("TOP"):
                        WindWave.GetComponent<WindPower>().WaveDirection.y = 1;
                        break;
                    case ("DOWN"):
                        WindWave.GetComponent<WindPower>().WaveDirection.y = (-1);
                        break;
                    case ("LEFT"):
                        animator.SetFloat("Direction", 1);
                        WindWave.GetComponent<WindPower>().WaveDirection.x = (-1);
                        break;
                    case ("RIGHT"):
                        animator.SetFloat("Direction", 0);
                        WindWave.GetComponent<WindPower>().WaveDirection.x = 1;
                        break;
                }
                StartCoroutine(FireCooldown());

            }
        }

        //temps entre les tirs
        IEnumerator FireCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(timeBetweenWave);
            canShoot = true;

        }
        
    }
}