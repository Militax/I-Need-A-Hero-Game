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

		[Header("Audio")]
		public AudioClip CollectAudio;


		private void Awake()
		{
			player = GameManager.Instance.player.transform;
		}

		private void Update()
		{
			float step = speed * Time.deltaTime;
			distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);

			if (distanceToPlayer <= CollectingRange && GameManager.Instance.CoinOwned < GameManager.Instance.maxCoin)
			{
				transform.position = Vector3.MoveTowards(gameObject.transform.position, player.position,step);
			}
		}
		//récupération des pièces et incrémentation de ++ dans le compteur de pièces
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.tag == "Player")
			{
				if (GameManager.Instance.CoinOwned < GameManager.Instance.maxCoin)
                {
					SoundManager.instance.PlaySfx(CollectAudio, 1, 1);

					if ((GameManager.Instance.CoinOwned + coinValue) <= GameManager.Instance.maxCoin)
					{
						GameManager.Instance.CoinOwned += coinValue;
					}
					else
					{
						GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;
					}
                    

                    GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
                    GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);

                    Destroy(gameObject);
                }
				else if (GameManager.Instance.CoinOwned < GameManager.Instance.maxCoin)
				{
					GameManager.Instance.CoinOwned = GameManager.Instance.maxCoin;
				}
			}
		}
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(gameObject.transform.position, CollectingRange);
		}
	}

}
