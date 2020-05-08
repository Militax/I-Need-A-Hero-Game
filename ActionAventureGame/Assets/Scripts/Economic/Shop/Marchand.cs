﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
using GameManagement;

public class Marchand : MonoBehaviour 
{
	[HideInInspector]
   public bool CanEnterShop = false;
   public GameObject shopUI;
   public GameObject startInputShop;

	void Start()
	{
		GameManager.Instance.GetComponentInChildren<ShopInteraction>().spr = this.GetComponent<SpriteRenderer>();
		GameManager.Instance.GetComponentInChildren<KeysBrightness>().marchand = this;
	}
	void Update ()
   {
		if (CanEnterShop)
		{
			if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == false) 
			{
				GameManager.Instance.playerCanMove = false;
				shopUI.SetActive (true);
				{
					  if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == true) 
					   {
							
							startInputShop.SetActive (false);
							Debug.Log("je suis dans la boutique le bouton est éteint");
						}
				}
				
			}
				
			else if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == true)
			{
				GameManager.Instance.playerCanMove = true;
				shopUI.SetActive (false); 
				{
					  if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == false) 
					   {
							startInputShop.SetActive (true);
							Debug.Log("je suis dans la boutique le bouton est alumé");
						}
				}
			}
		}

		
   }


   void OnTriggerEnter2D(Collider2D other)
   {
		if (other.tag == "Player")
		{
			
			CanEnterShop = true;
			startInputShop.SetActive(true);
			Debug.Log("le bouton s'affiche");

			if (shopUI.activeSelf == true)
			{
				startInputShop.SetActive(false);
				Debug.Log("je suis dans la boutique le bouton est éteint");
			}
		}
   	   
	   
   }

   void OnTriggerExit2D(Collider2D other)
   {
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerMovement>().enabled = true;
			CanEnterShop = false;
			startInputShop.SetActive(false);
		}
   	   
	  

   }
    
}
