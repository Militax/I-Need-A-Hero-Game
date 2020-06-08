using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CaptureFeeGelVoice : MonoBehaviour
    {
        public AudioClip voiceLine25;
        public AudioClip voiceLine63;


        public void Play25()
        {
            SoundManager.instance.PlayVoices(voiceLine25, 1);
        }
        public void Play63()
        {
            SoundManager.instance.PlayVoices(voiceLine63, 1);
        }
    }
}