using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class MoneyCount : MonoBehaviour
{
    public Text CurrentMoney;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
    }
    public void UpdateMoneyDisplay(int coins)
    {
        string currentcoins = coins.ToString();
        CurrentMoney.text = currentcoins;
    }
}
