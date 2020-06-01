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

        return;
    }

    /// <summary>
    /// Plays a given sfx. Specific volume and pitch can be specified in parameters.
    /// </summary>
    public void PlaySfx(AudioClip sfx, float volume, float pitch)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(sfx, sfxDefaultVolume * volume);

        sfxSource.pitch = 1;

        return;
    }

    /// <summary>
    /// Plays a given voice.
    /// </summary>
    public void PlayVoices(AudioClip voice, float volume)
    {
        voiceSource.PlayOneShot(voice, voicesDefaultVolume * volume);

        return;
    }

    // = = =

}