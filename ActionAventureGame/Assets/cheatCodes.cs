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
	public string donjon;

    int HPmaxBeforeCheat;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(invulnerability))
            {
                
                //GameManager.Instance.playerHealthMax = 1000;
                GameManager.Instance.invulnerabilityduration = 10000;
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
                //GameManager.Instance.playerHealthMax = HPmaxBeforeCheat;
                GameManager.Instance.invulnerabilityduration = 0.5f;
            }
            else if (Input.GetKey(tpBoss))
            {
                GameManager.Instance.playerHealthMax = 10;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
                GameManager.Instance.powerState = 3;
                SceneManager.LoadScene("Boss");
            }
			else if (Input.GetKey(donjon))
			{
				
                //GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            
                SceneManager.LoadScene("Donjon");
			}
        }
        

    }
}
