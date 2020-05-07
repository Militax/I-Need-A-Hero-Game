using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using TMPro;

public class MoneyCount : MonoBehaviour
{

    public Score Coins;
    public TextMeshProUGUI CoinCountObject;


    void Start()
    {
        UpdateMoneyDisplay(GameManager.Instance.CoinOwned);


        //Assignation des valeurs dans le Game Manager
        if (GameManager.Instance.GetComponent<CanvasManagement>().CoinCount == null)
        {
            GameManager.Instance.GetComponent<CanvasManagement>().CoinCount = CoinCountObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
    }
    public void UpdateMoneyDisplay(int coins)
    {
        Coins.clear();
        Coins.SetValue(coins);
    }
}
