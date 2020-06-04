using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class PlayVoice : MonoBehaviour
{
    public AudioClip NarratorVoice;
    public bool beforeDonjon;
    public int narrativeStatNeeded;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerFeet" && GameManager.Instance.isComingFromDonjon != beforeDonjon)
        {
            if (GameManager.Instance.NarrativeStat == narrativeStatNeeded)
            {
                SoundManager.instance.PlayVoices(NarratorVoice, 1);
                Destroy(gameObject);
            }
        }
    }



}