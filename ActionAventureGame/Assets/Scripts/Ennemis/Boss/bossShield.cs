using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class bossShield : MonoBehaviour
    {
        public int shieldLife = 2;

        void Update()
        {
            if (shieldLife <= 0)
            {
                Destroy(gameObject);
                GetComponentInParent<BossComportement>().isStunt = true;
                GetComponentInParent<BossComportement>().shieldActive = false;
            }

        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                Destroy(other.gameObject);
            }
            if (other.CompareTag("LightBullet") && other.GetComponent<LightBall>().isOut)
            {
                shieldLife--;
                Destroy(other.gameObject);
            }
        }
        
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("LightBullet"))
            {
                if (other.GetComponent<LightBall>().isOut == false)
                {
                    other.GetComponent<LightBall>().isOut = true;
                }
            }
        }
    }
}