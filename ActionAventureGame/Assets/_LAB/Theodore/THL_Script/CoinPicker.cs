using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using GameManagement;



/// <summary>
/// Theodore Labyt
/// 
/// Pick up coin
/// </summary>

namespace Economic
{
	public class CoinPicker : MonoBehaviour
	{
		//public TextMeshProUGUI textCoins;

		//récupération des pièces et incrémentation de ++ dans le compteur de pièces
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.tag == "Player")
			{
				GameManager.Instance.CoinOwned++;
				Debug.Log(GameManager.Instance.CoinOwned);
				//textCoins.text = coin.ToString();

				Destroy(gameObject);
			}
		}

	}
}
