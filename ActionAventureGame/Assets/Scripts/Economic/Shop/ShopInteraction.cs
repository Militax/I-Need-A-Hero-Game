using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class ShopInteraction : MonoBehaviour 
{
	

	// achat de 2 types de bottes
	// type 1 = 100 coins
	// type 2 = 200 coins
	public void bottesState()
	{

		if(GameManager.Instance.bottesState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 100)

			{
				Debug.Log("achat des bottes type 1");
				GameManager.Instance.bottesState = 1;
				GameManager.Instance.CoinOwned -= 100;
			}
	

		}
		else if (GameManager.Instance.bottesState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 200)
			{
				Debug.Log("achat des bottes type 2");
				GameManager.Instance.bottesState = 2;
				GameManager.Instance.CoinOwned -= 200;
			}
		}
	}

	//achat d'amélioration de la bourse 
	// bourse de 300 = 50 coins
	// bourse de 500 = 150 coins
	// bourse de 1000 = 300 coins
	public void maxCoin()
	{

		if(GameManager.Instance.maxCoin == 50)
		{
			if(GameManager.Instance.CoinOwned >= 50)

			{
				Debug.Log("achat de la bourse type 1");
				GameManager.Instance.maxCoin = 300;
				GameManager.Instance.CoinOwned -= 50;
				
			}
	

		}
		else if (GameManager.Instance.maxCoin == 300)
		{
			if(GameManager.Instance.CoinOwned >= 150)
			{
				Debug.Log("achat la bourse type 2");
				GameManager.Instance.maxCoin = 500;
				GameManager.Instance.CoinOwned -= 150;
			}
			
		}
		else if (GameManager.Instance.maxCoin == 500)
		{	
			if(GameManager.Instance.CoinOwned >= 300)
			{
				Debug.Log("achat la bourse type 3");
				GameManager.Instance.maxCoin = 1000;
				GameManager.Instance.CoinOwned -= 300;
			}
		
		}



	}

	// Achat des emplacement pour les coeurs
	// coeur 6 = 50 coins
	// coeur 7 = 70 coins
	// coeur 8 = 150 coins
	// coeur 9 = 300 coins
	// coeur 10 = 600 coins
	 public void playerHealthMax()
	{
		// coeur 6
		if(GameManager.Instance.playerHealthMax == 5)
		{
			if(GameManager.Instance.CoinOwned >= 50)

			{
				Debug.Log("coeur6");
				GameManager.Instance.playerHealthMax = 6;
				GameManager.Instance.playerHealth = 6;
				GameManager.Instance.CoinOwned -= 50;
			}
	

		}
		//coeur 7
		else if (GameManager.Instance.playerHealthMax == 6)
		{
			if(GameManager.Instance.CoinOwned >= 70)

			{
				Debug.Log("coeur7");
				GameManager.Instance.playerHealthMax = 7;
				GameManager.Instance.playerHealth = 7;
				GameManager.Instance.CoinOwned -= 70;
			}
			
		}
		// coeur 8
		else if (GameManager.Instance.playerHealthMax == 7)
		{	
			if(GameManager.Instance.CoinOwned >= 150)

			{
				Debug.Log("coeur8");
				GameManager.Instance.playerHealthMax = 8;
				GameManager.Instance.playerHealth = 8;
				GameManager.Instance.CoinOwned -= 150;
			}
		
		}
		// coeur 9
		else if (GameManager.Instance.playerHealthMax == 8)
		{
			if(GameManager.Instance.CoinOwned >= 300)

			{
				Debug.Log("coeur9");
				GameManager.Instance.playerHealthMax = 9;
				GameManager.Instance.playerHealth = 9;
				GameManager.Instance.CoinOwned -= 300;
			}
		}
		// coeur 10
		else if (GameManager.Instance.playerHealthMax == 9)
		{
			if(GameManager.Instance.CoinOwned >= 600)

			{
				Debug.Log("coeur10");
				GameManager.Instance.playerHealthMax = 10;
				GameManager.Instance.playerHealth = 10;
				GameManager.Instance.CoinOwned -= 600;
			}
		}
	}
}




	
  

