using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class ShopPrix : MonoBehaviour
{
	public GameObject maxCoinlvl1;
	public GameObject maxCoinlvl2;
	public GameObject maxCoinlvl3;
	public GameObject maxCoinEpuise;

	public GameObject botteslvl1;
	public GameObject botteslvl2;
	public GameObject bottesEpuise;

	public GameObject emptyHearth6;
	public GameObject emptyHearth7;
	public GameObject emptyHearth8;
	public GameObject emptyHearth9;
	public GameObject emptyHearth10;
	public GameObject emptyHearthEpuise;

	void Update ()
	{
		// les prix des bourse plus grande 
		if (GameManager.Instance.maxCoin == 50)
		{
			maxCoinlvl1.SetActive (true);
			maxCoinlvl2.SetActive (false);
			maxCoinlvl3.SetActive (false);
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin == 150)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (true);
			maxCoinlvl3.SetActive (false);
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin == 500)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (false);
			maxCoinlvl3.SetActive (true);
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin == 1000)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (false);
			maxCoinlvl3.SetActive (false);
			maxCoinEpuise.SetActive (true);
		}
	
	
		// les prix des Niveau des bottes
		if (GameManager.Instance.bottesState == 0)
		{
			botteslvl1.SetActive (true);
			botteslvl2.SetActive (false);
			bottesEpuise.SetActive (false);
		
		}
		else if (GameManager.Instance.bottesState == 1)
		{
			botteslvl1.SetActive (false);
			botteslvl2.SetActive (true);
			bottesEpuise.SetActive (false);
		}
		else if (GameManager.Instance.bottesState == 2)
		{
			botteslvl1.SetActive (false);
			botteslvl2.SetActive (false);
			bottesEpuise.SetActive (true);
		}


		// les prix des coeurs en plus 
		if(GameManager.Instance.playerHealthMax == 5)
		{
			emptyHearth6.SetActive (true);
			emptyHearth7.SetActive (false);
			emptyHearth8.SetActive (false);
			emptyHearth9.SetActive (false);
			emptyHearth10.SetActive (false);
			emptyHearthEpuise.SetActive (false);
		}
		else if (GameManager.Instance.playerHealthMax == 6)
		{
			emptyHearth6.SetActive (false);
			emptyHearth7.SetActive (true);
			emptyHearth8.SetActive (false);
			emptyHearth9.SetActive (false);
			emptyHearth10.SetActive (false);
			emptyHearthEpuise.SetActive (false);
		}
		else if (GameManager.Instance.playerHealthMax == 7)
		{
			emptyHearth6.SetActive (false);
			emptyHearth7.SetActive (false);
			emptyHearth8.SetActive (true);
			emptyHearth9.SetActive (false);
			emptyHearth10.SetActive (false);
			emptyHearthEpuise.SetActive (false);
		}
		else if (GameManager.Instance.playerHealthMax ==8)
		{
			emptyHearth6.SetActive (false);
			emptyHearth7.SetActive (false);
			emptyHearth8.SetActive (false);
			emptyHearth9.SetActive (true);
			emptyHearth10.SetActive (false);
			emptyHearthEpuise.SetActive (false);
		}
		else if (GameManager.Instance.playerHealthMax == 9)
		{
			emptyHearth6.SetActive (false);
			emptyHearth7.SetActive (false);
			emptyHearth8.SetActive (false);
			emptyHearth9.SetActive (false);
			emptyHearth10.SetActive (true);
			emptyHearthEpuise.SetActive (false);
		}
		else if (GameManager.Instance.playerHealthMax == 10)
		{
			emptyHearth6.SetActive (false);
			emptyHearth7.SetActive (false);
			emptyHearth8.SetActive (false);
			emptyHearth9.SetActive (false);
			emptyHearth10.SetActive (false);
			emptyHearthEpuise.SetActive (true);
		}
	}









}
