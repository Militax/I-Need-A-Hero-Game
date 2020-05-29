using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

public class explosion : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && GameManager.Instance.invulnerability == false)
        {
            GameManager.Instance.playerHealth -= 3;
            SoundManager.instance.PlaySfx(Damage, 1, 1);
            GameManager.Instance.invulnerability = true;
            

        }
    }
}
