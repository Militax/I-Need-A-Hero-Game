using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;

public class BossLifeUI : MonoBehaviour
{
    public GameObject boss;

    public GameObject bossLife6;
    public GameObject bossLife5;
    public GameObject bossLife4;
    public GameObject bossLife3;
    public GameObject bossLife2;
    public GameObject bossLife1;


    [Header("Audio")]
    public AudioClip NarratorVoicePhase1;
    public AudioClip NarratorVoicePhase1bis;
    public AudioClip NarratorVoicePhase2;
    public AudioClip NarratorVoicePhase3;


    public void Update()
    {
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 0)
        {
            bossLife1.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 2)
        {
            if (!SoundManager.instance.voicePhase3)
            {
                SoundManager.instance.PlayVoices(NarratorVoicePhase3, 1);
                SoundManager.instance.voicePhase3 = true;
            }
            
            bossLife2.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 5)
        {
            bossLife3.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 8)
        {
            if (!SoundManager.instance.voicePhase2)
            {
                SoundManager.instance.PlayVoices(NarratorVoicePhase2, 1);
                SoundManager.instance.voicePhase2 = true;
            }

            bossLife4.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 10)
        {
            if (!SoundManager.instance.voicePhase1bis)
            {
                SoundManager.instance.PlayVoices(NarratorVoicePhase1bis, 1);
                SoundManager.instance.voicePhase1bis = true;
            }

            bossLife5.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 13)
        {
            if (!SoundManager.instance.voicePhase1)
            {
                SoundManager.instance.PlayVoices(NarratorVoicePhase1, 1);
                SoundManager.instance.voicePhase1 = true;
            }

            bossLife6.SetActive(false);
        }
    }
}