using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère l'eau qui se gèle et se dégèle
    /// </summary>
    public class WaterAndIce : MonoBehaviour
    {
        public GameObject waterClear;
        public GameObject waterFrozen;
        public float freezeDuration;

        bool isFrozen = false;

        private void Start()
        {
            waterClear.SetActive(true);
            waterFrozen.SetActive(false);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave") && GameManager.Instance.powerState >= 2 && !isFrozen)
            {
                waterClear.SetActive(false);
                waterFrozen.SetActive(true);

                StartCoroutine(FrozenTime());
            }
        }


        IEnumerator FrozenTime()
        {
            isFrozen = true;
            yield return new WaitForSeconds(freezeDuration);
            waterClear.SetActive(true);
            waterFrozen.SetActive(false);
            isFrozen = false;
        }


    }
}