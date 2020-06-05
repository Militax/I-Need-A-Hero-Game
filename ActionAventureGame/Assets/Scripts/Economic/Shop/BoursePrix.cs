using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class BoursePrix : MonoBehaviour
{
    public GameObject maxCoinlvl1;
	public GameObject maxCoinlvl2;
	
	public GameObject maxCoinEpuise;

   
    void Update()
    {
        // les prix des bourse plus grande 
		if (GameManager.Instance.maxCoin == 50)
		{
			Debug.Log("ca marche");
			maxCoinlvl1.SetActive (true);
			maxCoinlvl2.SetActive (false);
			
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin <= 300 && GameManager.Instance.maxCoin > 50)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (true);
			
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin <= 500 && GameManager.Instance.maxCoin >300 )
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (false);
			
			maxCoinEpuise.SetActive (true);
		}
		
    }
}
