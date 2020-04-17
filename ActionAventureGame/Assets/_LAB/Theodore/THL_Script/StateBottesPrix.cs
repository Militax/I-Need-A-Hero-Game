using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class StateBottesPrix : MonoBehaviour
{
	public GameObject botteslvl1;
	public GameObject botteslvl2;
	public GameObject bottesEpuise;

  
    void Update()
    // les prix des Niveau des bottes
	{
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
	}
}
