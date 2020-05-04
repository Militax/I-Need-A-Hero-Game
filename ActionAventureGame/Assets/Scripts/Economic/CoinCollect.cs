using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Economic;



/// <summary>
/// Theodore Labyt
/// 
/// Pick up coin
/// </summary>

namespace Economic
{
	public class CoinCollect : MonoBehaviour
	{

		//récupération des pièces et incrémentation de ++ dans le compteur de pièces
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.tag == "Player")
			{
				GameManager.Instance.CoinOwned++;
				GameObject.FindObjectOfType<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameObject.FindObjectOfType<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
				Destroy(gameObject);
			}
		}

	}
}
