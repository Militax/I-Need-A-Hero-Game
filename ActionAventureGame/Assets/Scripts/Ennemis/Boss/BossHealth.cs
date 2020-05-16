using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        #region Variables
        public int CurrentBossLife;
        public int maxBossLife;

        int lifeByPhase;
        int NbPhase;
        public bool haveToChange = false;
        bool haveChange = false;
        int lifeStat;

        bool canTakeDamage= true;

        public Animator animator;
        #endregion


        void Start()
        {
            CurrentBossLife = maxBossLife;
            NbPhase = GetComponent<BossComportement>().numberOfPhases;
            lifeByPhase = maxBossLife / NbPhase;
        }
        void Update()
        {
            lifeManager();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter");
            if (other.CompareTag("Sword"))
            {
                CurrentBossLife--;
            }
        }


        void lifeManager()
        {
            for (int n = 1; n < NbPhase; n++)
            {
                

                if (CurrentBossLife == lifeByPhase*n)
                {
                    lifeStat = CurrentBossLife;
                    Debug.Log("Must Change" + " " + n);

                    
                    if(haveToChange == false && haveChange == false)
                    {
                        haveToChange = true;
                        animator.SetTrigger("Change");
                        haveChange = true;
                    }
                }

                if (CurrentBossLife != lifeStat && haveChange)
                {
                    Debug.Log("DONE");

                    haveChange = false;
                }
            }

            if (CurrentBossLife <= 0)
            {
                Death();
            }
        }
        void Death()
        {
            Destroy(gameObject);
        }
    }
}