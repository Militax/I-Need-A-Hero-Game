using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class cheatCodes : MonoBehaviour
{
    public string invulnerability;
    public string die;
    public string money;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(invulnerability))
        {
            GameManager.Instance.playerHealthMax = 1000;
            GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
        }
        else if (Input.GetKey(die))
        {
            GameManager.Instance.playerHealth = 0;
        }
        else if (Input.GetKey(money))
        {
            GameManager.Instance.maxCoin = 10000;
            GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;

        }

    }
}
