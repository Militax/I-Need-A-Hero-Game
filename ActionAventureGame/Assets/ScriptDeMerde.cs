using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScriptDeMerde : MonoBehaviour
    {
        public GameObject sonAfAIRE;
        public float time;

        private void Start()
        {
            sonAfAIRE.SetActive(false);
            StartCoroutine(CinematiqueTime());
        }


        IEnumerator CinematiqueTime()
        {
            yield return new WaitForSeconds(time);
            sonAfAIRE.SetActive(true);
        }
        
        
        
    }
}