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



    }
    
    public void UpdateMoneyDisplay(int coins)
    {
        Coins.clear();
        Coins.SetValue(coins);
    }
}
