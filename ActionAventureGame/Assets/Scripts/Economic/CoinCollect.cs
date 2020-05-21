using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Economic;
using Player;



/// <summary>
/// Theodore Labyt
/// 
/// Pick up coin
/// </summary>

namespace Economic
{
	
	public class CoinCollect : MonoBehaviour
	{
		Transform player;
		public int coinValue;
		public float CollectingRange;
		public float speed;
		public float distanceToPlayer;
		private void Awake()
		{
			player = FindObjectOfType<PlayerMovement>().transform;
			
		}

		private void Update()
		{
			float step = speed * Time.deltaTime;
			distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);

			if (distanceToPlayer <= CollectingRange)
			{
				transform.position = Vector3.MoveTowards(gameObject.transform.position, player.position,step);
			}
			
		}
		//récupération des pièces et incrémentation de ++ dans le compteur de pièces
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.tag == "Player")
			{
				GameManager.Instance.CoinOwned += coinValue;

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);

				Destroy(gameObject);
			}
		}
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(gameObject.transform.position, CollectingRange);
		}
	}

}
