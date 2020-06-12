using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using UnityEngine.SceneManagement;

public class cheatCodes : MonoBehaviour
{
    public string invulnerability;
    public string die;
    public string money;
	public string normalLife;
    public string tpBoss;

    int HPmaxBeforeCheat;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(invulnerability))
            {
                HPmaxBeforeCheat = GameManager.Instance.playerHealthMax;
                GameManager.Instance.playerHealthMax = 1000;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
            else if (Input.GetKey(die))
            {
                GameManager.Instance.playerHealth = 0;
            }
            else if (Input.GetKey(money))
            {
                GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;
                //GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;

            }
            else if (Input.GetKey(normalLife))
            {
                GameManager.Instance.playerHealthMax = HPmaxBeforeCheat;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
            else if (Input.GetKey(tpBoss))
            {
                GameManager.Instance.playerHealthMax = 10;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
                GameManager.Instance.powerState = 3;
                SceneManager.LoadScene("Boss");
            }
        }
        

    }
}
