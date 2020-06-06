using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class cheatCodes : MonoBehaviour
{
    public string invulnerability;
    public string die;
    public string money;
	public string normalLife;

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
            GameManager.Instance.CoinOwned =+ 10000;
            //GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;

        }
		else if (Input.GetKey(normalLife))
		{
			GameManager.Instance.playerHealthMax = 5;
            GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
		}

    }
}
