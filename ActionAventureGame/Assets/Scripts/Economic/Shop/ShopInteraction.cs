using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using Economic;
public class ShopInteraction : MonoBehaviour 
{
	int coinsCollected;
	public Sprite MaisonPaille;
	public Sprite MaisonBois;
	public Sprite MaisonBrique;
	

	public SpriteRenderer spr;
	ThresholdBourse threshold;

	[Header ("Audio")]
	public AudioClip BuyAudio;
	public AudioClip BuyDeniedAudio;


	private void Start()
	{
		threshold = GameManager.Instance.GetComponentInChildren<ThresholdBourse>();
	}
	private void Update()
	{
		if (spr != null)
		{
			if (coinsCollected <= 900)
			{
				spr.sprite = MaisonPaille;
			}
			else if (coinsCollected > 900 && coinsCollected < 1600)
			{
				spr.sprite = MaisonBois;
			}
			else if (coinsCollected >= 1600)
			{
				spr.sprite = MaisonBrique;
			}
		}
	}
	// achat de 2 types de bottes
	// type 1 = 400 coins
	// type 2 = 1000 coins
	public void bottesState()
	{

		if(GameManager.Instance.bottesState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 400)
			{
				Debug.Log("achat des bottes type 1");
				GameManager.Instance.bottesState = 1;
				GameManager.Instance.CoinOwned -= 400;
				coinsCollected += 400;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
	

		}
		else if (GameManager.Instance.bottesState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 1000)
			{
				Debug.Log("achat des bottes type 2");
				GameManager.Instance.bottesState = 2;
				GameManager.Instance.CoinOwned -= 1000;
				coinsCollected += 1000;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
		}
	}

	//achat d'amélioration de la bourse 
	// bourse de 2000 = 300 coins
	// bourse de 5000 = 1000 coins

	public void maxCoin()
	{

		if(GameManager.Instance.maxCoin == 1000)
		{
			if(GameManager.Instance.CoinOwned >= 1000)

			{
				Debug.Log("achat de la bourse type 1");
				GameManager.Instance.maxCoin = 2000;
				GameManager.Instance.CoinOwned -= 300;
				coinsCollected += 300;
				threshold.BourseLevel = 1;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}


		}
		else if (GameManager.Instance.maxCoin == 2000)
		{
			if(GameManager.Instance.CoinOwned >= 1000)
			{
				Debug.Log("achat la bourse type 2");
				GameManager.Instance.maxCoin = 5000;
				GameManager.Instance.CoinOwned -= 1000;
				coinsCollected += 1000;
				threshold.BourseLevel = 2;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}

		}
		



	}

	// Achat des emplacement pour les coeurs
	// coeur 6 = 200 coins
	// coeur 7 = 400 coins
	// coeur 8 = 600 coins
	// coeur 9 = 800 coins
	// coeur 10 = 1000 coins
	 public void playerHealthMax()
	{
		// coeur 6
		if(GameManager.Instance.playerHealthMax == 5)
		{
			if(GameManager.Instance.CoinOwned >= 200)

			{
				Debug.Log("coeur6");
				GameManager.Instance.playerHealthMax = 6;
				GameManager.Instance.playerHealth = 6;
				GameObject.FindObjectOfType<CanvasManagement>().UpdateBar(GameManager.Instance.playerHealth);
				GameManager.Instance.CoinOwned -= 200;
				coinsCollected += 200;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}


		}
		//coeur 7
		else if (GameManager.Instance.playerHealthMax == 6)
		{
			if(GameManager.Instance.CoinOwned >= 400)

			{
				Debug.Log("coeur7");
				GameManager.Instance.playerHealthMax = 7;
				GameManager.Instance.playerHealth = 7;
				GameObject.FindObjectOfType<CanvasManagement>().UpdateBar(GameManager.Instance.playerHealth);
				GameManager.Instance.CoinOwned -= 400;
				coinsCollected += 400;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}

		}
		// coeur 8
		else if (GameManager.Instance.playerHealthMax == 7)
		{	
			if(GameManager.Instance.CoinOwned >= 600)

			{
				Debug.Log("coeur8");
				GameManager.Instance.playerHealthMax = 8;
				GameManager.Instance.playerHealth = 8;
				GameObject.FindObjectOfType<CanvasManagement>().UpdateBar(GameManager.Instance.playerHealth);
				GameManager.Instance.CoinOwned -= 600;
				coinsCollected += 600;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}

		}
		// coeur 9
		else if (GameManager.Instance.playerHealthMax == 8)
		{
			if(GameManager.Instance.CoinOwned >= 800)

			{
				Debug.Log("coeur9");
				GameManager.Instance.playerHealthMax = 9;
				GameManager.Instance.playerHealth = 9;
				GameObject.FindObjectOfType<CanvasManagement>().UpdateBar(GameManager.Instance.playerHealth);
				GameManager.Instance.CoinOwned -= 800;
				coinsCollected += 800;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}
		}
		// coeur 10
		else if (GameManager.Instance.playerHealthMax == 9)
		{
			if(GameManager.Instance.CoinOwned >= 1000)

			{
				Debug.Log("coeur10");
				GameManager.Instance.playerHealthMax = 10;
				GameManager.Instance.playerHealth = 10;
				GameObject.FindObjectOfType<CanvasManagement>().UpdateBar(GameManager.Instance.playerHealth);
				GameManager.Instance.CoinOwned -= 1000;
				coinsCollected += 1000;

				SoundManager.instance.PlaySfx(BuyAudio, 1, 1);

				GameManager.Instance.GetComponentInChildren<ThresholdBourse>().UpdateCoinsDisplay(GameManager.Instance.CoinOwned);
				GameManager.Instance.GetComponentInChildren<MoneyCount>().UpdateMoneyDisplay(GameManager.Instance.CoinOwned);
			}
			else
			{
				SoundManager.instance.PlaySfx(BuyDeniedAudio, 1, 1);
			}
		}
	}
}




	
  

