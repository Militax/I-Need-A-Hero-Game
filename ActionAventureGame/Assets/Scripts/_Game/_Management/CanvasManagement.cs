using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameManagement
{
    /// <summary>
    /// Gère l'affichage en jeu des informations
    /// </summary>
    public class CanvasManagement : MonoBehaviour
    {
        #region PlayerLife
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        #endregion

        #region Economic
        public TextMeshProUGUI CoinCount;
        #endregion

        void Start()
        {
            
        }
        
        void Update()
        {
            EconomicCanvas();
            PlayerLifeCanvas();
        }



        //Gère l'affichage des valeurs relatives à l'économie
        void EconomicCanvas()
        {
            CoinCount.text = GameManager.Instance.CoinOwned.ToString();
        }
        void PlayerLifeCanvas()
        {
            if (GameManager.Instance.playerHealth > GameManager.Instance.playerHealthMax)
            {
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }

            for (int i = 0; i < hearts.Length; i++)
            {

                if (i < GameManager.Instance.playerHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < GameManager.Instance.playerHealthMax)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }

            }
        }
    }
}