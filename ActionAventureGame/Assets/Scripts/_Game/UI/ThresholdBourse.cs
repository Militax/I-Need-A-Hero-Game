using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using System.Linq;

namespace Economic
{
    public class ThresholdBourse : MonoBehaviour
    {

        public Image Bourse;
        Sprite baseimage;


        [System.Serializable]
        public class threshold
        {
            public int Coins;
            public Sprite accordingSprite;
        }

        public threshold[] thresholds;

        public void UpdateCoinsDisplay(int coins)
        {
            thresholds = thresholds.OrderByDescending(t => t.Coins).ToArray();
            foreach (threshold item in thresholds)
            {
                if (coins >= item.Coins)
                {
                    Bourse.sprite = item.accordingSprite;
                    return;
                }
                if (coins < 0)
                {
                    
                    Bourse.sprite = baseimage;
                }
            }
        }
        private void Start()
        {
            Bourse = Bourse.GetComponent<Image>();
            baseimage = Bourse.GetComponent<Image>().sprite;
            UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
        }
        private void Update()
        {
            UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
        }
    }
}

