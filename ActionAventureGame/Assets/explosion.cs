using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

public class explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.playerHealth -= 3;
        }
    }
}
