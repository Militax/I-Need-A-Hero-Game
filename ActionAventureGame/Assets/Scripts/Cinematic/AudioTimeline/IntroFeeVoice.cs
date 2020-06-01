using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class IntroFeeVoice : MonoBehaviour
    {
        public AudioClip voiceLine9;
        public AudioClip voiceLine10;
        public AudioClip voiceLine11;
        public AudioClip voiceLine12;


        public void Play9()
        {
            SoundManager.instance.PlayVoices(voiceLine9, 1);
        }
        public void Play10()
        {
            SoundManager.instance.PlayVoices(voiceLine10, 1);
        }
        public void Play11()
        {
            SoundManager.instance.PlayVoices(voiceLine11, 1);
        }
        public void Play12()
        {
            SoundManager.instance.PlayVoices(voiceLine12, 1);
        }



    }
}