using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class HopLa : MonoBehaviour
{
    public AudioClip NarratorVoice68;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerFeet" && GameManager.Instance.powerState >= 3)
        {
            SoundManager.instance.PlayVoices(NarratorVoice68, 1);
            Destroy(gameObject);
        }
    }

}