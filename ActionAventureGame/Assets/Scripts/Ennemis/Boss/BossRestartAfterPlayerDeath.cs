using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameManagement;

public class BossRestartAfterPlayerDeath : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.Instance.playerHealth <= 0)
        {
            GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
