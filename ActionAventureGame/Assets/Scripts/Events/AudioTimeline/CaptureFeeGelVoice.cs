using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Game
{
    public class CaptureFeeGelVoice : MonoBehaviour
    {
        public AudioClip voiceLine25;
        public AudioClip voiceLine63;


        public void Play25()
        {
            SoundManager.instance.PlayVoices(voiceLine25, 1);
            GameManager.Instance.powerState = 2;
            Debug.Log("Hou Hi Hou Ha Ha");
        }
        public void Play63()
        {
            SoundManager.instance.PlayVoices(voiceLine63, 1);  
        }
    }
}