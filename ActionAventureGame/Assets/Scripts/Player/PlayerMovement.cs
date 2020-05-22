using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

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
        private float aimIdleX;
        private float aimIdleY;
        public float bottes1;
        public float bottes2;
        public float bottes3;
        public Rigidbody2D rb;
        public Vector2 movement;
        PlayerAttack PlayerAttack;

        bool footStepCoroutine = false;

        void Start()
        {
            PlayerAttack = GetComponent<PlayerAttack>();
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

            if (movement.x != 0)
            {
                animator.SetFloat("Horizontal Idle", movement.x);
            }

            if (movement.y != 0)
            {
                animator.SetFloat("Vertical Idle", movement.y);
            }

            if (movement.x != 0 && movement.y == 0)
            {
                animator.SetFloat("Vertical Idle", -1);
            }

            if (GameManager.Instance.bottesState == 1)
            {
                moveSpeed = bottes1;                PlayerAttack.baseMoveSpeed = moveSpeed;
            }
            if (GameManager.Instance.bottesState == 2)
            {                
                moveSpeed = bottes2;                PlayerAttack.baseMoveSpeed = moveSpeed;
            }
            if (GameManager.Instance.bottesState == 3)
            {
                moveSpeed = bottes3;                PlayerAttack.baseMoveSpeed = moveSpeed;
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
            //AudioManager.AMInstance.Play(AudioManager.AMInstance.PlayerSounds, "Outside Step");
            float time = Random.Range(0.4f, 0.7f);
            yield return new WaitForSeconds(time);
            footStepCoroutine = false;
        }
    }
}