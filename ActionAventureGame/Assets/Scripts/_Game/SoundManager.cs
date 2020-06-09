using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// by Tristan Ledieu
/// </summary>
public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    // = = = [ VARIABLES DEFINITION ] = = =

    [Space(10)]
    [Header("Musics")]
    [Range(0f, 1f)] public float musicDefaultVolume = 1f;

    [Space(10)]
    [Header("SFX")]
    [Range(0f, 1f)] public float sfxDefaultVolume = 1f;

    [Space(10)]
    [Header("Voices")]
    [Range(0f, 1f)] public float voicesDefaultVolume = 1f;

    [Space(10)]
    [Header("References")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;
    

    #region VoicesLinesBool
    [HideInInspector]
    public bool voice8 = false;
    [HideInInspector]
    public bool voice13 = false;
    [HideInInspector]
    public bool voice15 = false;
    [HideInInspector]
    public bool voice16 = false;
    [HideInInspector]
    public bool voice17 = false;
    [HideInInspector]
    public bool voice19 = false;
    [HideInInspector]
    public bool voice20 = false;
    [HideInInspector]
    public bool voice21 = false;
    [HideInInspector]
    public bool voice22 = false;
    [HideInInspector]
    public bool voice24 = false;
    [HideInInspector]
    public bool voice25 = false;
    [HideInInspector]
    public bool voice26 = false;
    [HideInInspector]
    public bool voice27 = false;
    [HideInInspector]
    public bool voice28 = false;
    [HideInInspector]
    public bool voice29 = false;
    [HideInInspector]
    public bool voice30 = false;
    [HideInInspector]
    public bool voice31 = false;
    [HideInInspector]
    public bool voice32 = false;
    [HideInInspector]
    public bool voice33 = false;
    [HideInInspector]
    public bool voice34 = false;
    [HideInInspector]
    public bool voice35 = false;
    [HideInInspector]
    public bool voice36 = false;
    [HideInInspector]
    public bool voice37 = false;
    [HideInInspector]
    public bool voice38 = false;
    [HideInInspector]
    public bool voice39 = false;
    [HideInInspector]
    public bool voice40 = false;
    [HideInInspector]
    public bool voice41 = false;
    [HideInInspector]
    public bool voice42 = false;
    [HideInInspector]
    public bool voice43 = false;
    [HideInInspector]
    public bool voice44 = false;
    [HideInInspector]
    public bool voice45 = false;
    [HideInInspector]
    public bool voice46 = false;
    [HideInInspector]
    public bool voice47 = false;
    [HideInInspector]
    public bool voice48 = false;
    [HideInInspector]
    public bool voice49 = false;
    [HideInInspector]
    public bool voice50 = false;
    [HideInInspector]
    public bool voice51 = false;
    [HideInInspector]
    public bool voice52 = false;
    [HideInInspector]
    public bool voice53 = false;
    [HideInInspector]
    public bool voice54 = false;
    [HideInInspector]
    public bool voice55 = false;
    [HideInInspector]
    public bool voice56 = false;
    [HideInInspector]
    public bool voice57 = false;
    [HideInInspector]
    public bool voice58 = false;
    [HideInInspector]
    public bool voice59 = false;
    [HideInInspector]
    public bool voice60 = false;
    [HideInInspector]
    public bool voice61 = false;
    [HideInInspector]
    public bool voicePhase1 = false;
    [HideInInspector]
    public bool voicePhase1bis = false;
    [HideInInspector]
    public bool voicePhase2 = false;
    [HideInInspector]
    public bool voicePhase3 = false;


    #endregion


    // = = =

    // = = = [ MONOBEHAVIOR METHODS ] = = =

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
    }



    // = = =

    // = = = [ CLASS METHODS ] = = =

    /// <summary>
    /// Start playing a given music.
    /// </summary>
    public void PlayMusic(AudioClip music, float volume)
    {
        musicSource.clip = music;
        musicSource.volume = musicDefaultVolume * volume;

        musicSource.Play();
    }

    /// <summary>
    /// Plays a given sfx. Specific volume and pitch can be specified in parameters.
    /// </summary>
    public void PlaySfx(AudioClip sfx, float volume, float pitch)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(sfx, sfxDefaultVolume * volume);

        sfxSource.pitch = 1;

    }

    /// <summary>
    /// Plays a given voice.
    /// </summary>
    public void PlayVoices(AudioClip voice, float volume)
    {
        voiceSource.PlayOneShot(voice, voicesDefaultVolume * volume);
    }

    // = = =

    /// <summary>
    /// Set volume
    /// </summary>
    public void SetMusicVolume(Slider slider)
    {
        musicDefaultVolume = slider.value /100;
    }

    public void SetSFXVolume(Slider slider)
    {
        sfxDefaultVolume = slider.value / 100;
    }
    public void SetVoicesVolume(Slider slider)
    {
        voicesDefaultVolume = slider.value / 100;
    }
    // = = =

}