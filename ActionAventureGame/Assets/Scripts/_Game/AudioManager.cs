using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{

    /// <summary>
    /// Matis Duperray
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        //AudioManager.AMInstance.Play(AudioManager.AMInstance.TABLEAU, NOM);
        public static AudioManager AMInstance;


        public Sound[] Themes;
        public Sound[] NarratorVoiceLines;
        public Sound[] PlayerSounds;
        public Sound[] EnnemySounds;
        public Sound[] OtherSounds;

        void Awake()
        {
            if (AMInstance == null)
            {
                AMInstance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }


            InitiateSoundArray(Themes);
            InitiateSoundArray(NarratorVoiceLines);
            InitiateSoundArray(PlayerSounds);
            InitiateSoundArray(EnnemySounds);
            InitiateSoundArray(OtherSounds);
        }
        
        public void Play(Sound[] _tab, string _name)
        {
            Sound s = Array.Find(_tab, sound => sound.name == _name);
            if (s == null)
            {
                Debug.LogError("Audio Manager don't find the sound called : " + _name);
                return;
            }

            s.source.Play();
        }
        
        
        

        void InitiateSoundArray(Sound[] array)
        {
            foreach (Sound s in array)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }
    }
}