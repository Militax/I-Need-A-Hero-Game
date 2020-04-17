using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marchand : MonoBehaviour 
{
   bool CanEnterShop = false;
   
   public GameObject shopUI;
   public GameObject startInputShop;

   void Update ()
   {
		if (CanEnterShop)
		{
			if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == false) 
			{
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
		
   	   CanEnterShop = true;
	   startInputShop.SetActive (true);
	   Debug.Log("le bouton s'affiche");

	   if (shopUI.activeSelf == true)
	   {
			startInputShop.SetActive (false);
			Debug.Log("je suis dans la boutique le bouton est éteint");
	   }
	   
   }

   void OnTriggerExit2D(Collider2D other)
   {
   	   CanEnterShop = false;
	   startInputShop.SetActive (false);
	  

   }
    
}
