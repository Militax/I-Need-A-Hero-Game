using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class BoursePrix : MonoBehaviour
{
    public GameObject maxCoinlvl1;
	public GameObject maxCoinlvl2;
	public GameObject maxCoinlvl3;
	public GameObject maxCoinEpuise;

   
    void Update()
    {
        // les prix des bourse plus grande 
		if (GameManager.Instance.maxCoin == 50)
		{
			maxCoinlvl1.SetActive (true);
			maxCoinlvl2.SetActive (false);
			maxCoinlvl3.SetActive (false);
			maxCoinEpuise.SetActive (false);
		}
		else if (GameManager.Instance.maxCoin == 300)
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
    }
}
