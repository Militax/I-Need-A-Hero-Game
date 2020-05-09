using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WaitForAudio : MonoBehaviour
    {
        public float time;


        private void Start()
        {
            AudioSource source = GetComponent<AudioSource>();
            StartCoroutine(WaitForPlay(source, time));
        }


        IEnumerator WaitForPlay(AudioSource _source, float _time)
        {
            yield return new WaitForSeconds(_time);
            _source.enabled = true;
        }
    }
}