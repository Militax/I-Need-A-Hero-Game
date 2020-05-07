using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

public class HeartCollect : MonoBehaviour
{
	Transform player;
	public int HeartValue;
	public float CollectingRange;
	public float speed;
	float distanceToPlayer;
	private void Start()
	{
		player = FindObjectOfType<PlayerMovement>().transform;
	}

	private void Update()
	{
		float step = speed * Time.deltaTime;
		distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);

		if (distanceToPlayer <= CollectingRange)
		{
			transform.position = Vector3.MoveTowards(gameObject.transform.position, player.position, step);
		}
	}
	//récupération des pièces et incrémentation de ++ dans le compteur de pièces
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
			GameManager.Instance.playerHealth += HeartValue;
			
			Destroy(gameObject);
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(gameObject.transform.position, CollectingRange);
	}
}
