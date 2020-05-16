using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Audio;

/// <summary>
/// Matis Duperray
/// 
/// Deplacements du personnage
/// </summary>
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        public Animator animator;

        public Rigidbody2D rb;
        public Vector2 movement;


        bool footStepCoroutine = false;

        void Start()
        {
            //Recuperation du rigidbody du player
            rb = GetComponent<Rigidbody2D>();
            GameManager.Instance.player = this;
        }

        void Update()
        {
            //Les valeurs du vecteur sont celles des valeurs des axes d'input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (!animator)
                return;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if (GameManager.Instance.bottesState == 1)
            {
                moveSpeed = 3.5f;
            }
            if (GameManager.Instance.bottesState == 2)
            {
                moveSpeed = 4f;
            }
            if (GameManager.Instance.bottesState == 3)
            {
                moveSpeed = 4.3f;
            }



            if(rb.velocity != Vector2.zero)
            {
                if (footStepCoroutine == false)
                {
                    StartCoroutine(FootStep());
                }
            }
        }

        private void FixedUpdate()
        {

            if (GameManager.Instance.playerCanMove)
            {
                rb.velocity = movement.normalized * (moveSpeed * 50) * Time.deltaTime;
            }
                
        }

        IEnumerator FootStep()
        {
            footStepCoroutine = true;
            AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Outside Step");
            float time = Random.Range(0.4f, 0.7f);
            yield return new WaitForSeconds(time);
            footStepCoroutine = false;
        }
    }
}