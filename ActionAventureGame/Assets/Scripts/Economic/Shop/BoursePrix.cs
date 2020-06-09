using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using Economic;

public class BoursePrix : MonoBehaviour
{
    public GameObject maxCoinlvl1;
	public GameObject maxCoinlvl2;
	
	public GameObject maxCoinEpuise;
	ThresholdBourse threshold;

	private void Start()
	{
		threshold = GameManager.Instance.GetComponentInChildren<ThresholdBourse>();
	}
	void Update()
    {
        // les prix des bourse plus grande 
		if (threshold.BourseLevel == 0)
		{
			Debug.Log("ca marche");
			maxCoinlvl1.SetActive (true);
			maxCoinlvl2.SetActive (false);
			
			maxCoinEpuise.SetActive (false);
		}
		else if (threshold.BourseLevel == 1)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (true);
			
			maxCoinEpuise.SetActive (false);
		}
		else if (threshold.BourseLevel == 2)
		{
			maxCoinlvl1.SetActive (false);
			maxCoinlvl2.SetActive (false);
			
			maxCoinEpuise.SetActive (true);
		}
		
    }
}
