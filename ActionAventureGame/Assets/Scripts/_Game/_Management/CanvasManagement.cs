using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace GameManagement
{
    /// <summary>
    /// Gère l'affichage en jeu des informations
    /// </summary>
    public class CanvasManagement : MonoBehaviour
    {
        [System.Serializable]
        public class Bars
        {
            public int Health; 
            public Sprite Bar;
        }
        public Bars[] bars;
        #region PlayerLife
        public Image[] hearts;
        public Image hpBar;
        Sprite BaseBar;
        
        public Sprite fullHeart;
        public Sprite emptyHeart;
        #endregion



        [Header ("Canvas Elements")]
        public GameObject BossLifeUI;
        public GameObject playerHealth;
        public GameObject Input;
        public GameObject bourse;
        public GameObject score;
        public GameObject timer;



        void Start()
        {
            hpBar = hpBar.GetComponent<Image>();
            BaseBar = hpBar.GetComponent<Image>().sprite;
            UpdateBar(GameManager.Instance.playerHealth);
        }
        
        void Update()
        {
            PlayerLifeCanvas();
            UpdateBar(GameManager.Instance.playerHealthMax);
            
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
        public void UpdateBar(int hp)
        {
            bars = bars.OrderByDescending(t => t.Health).ToArray();
            foreach (Bars item in bars)
            {
                if (hp >= item.Health)
                {
                    hpBar.sprite = item.Bar;
                    return;
                }
                if (hp < 0)
                {

                    hpBar.sprite = BaseBar;
                }
            }
        }
    }
}