using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

public class StepAudioChanger : MonoBehaviour
{
    public bool isStone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isStone)
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnStone = true;
            GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnIce = false;
        }
        else
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnStone = false;
            GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnIce = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnStone = false;
        GameManager.Instance.player.GetComponent<PlayerMovement>().walkOnIce = false;
    }
}