using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class EmptyHearthPrix : MonoBehaviour
{
    public GameObject emptyHearth6;
	public GameObject emptyHearth7;
	public GameObject emptyHearth8;
	public GameObject emptyHearth9;
	public GameObject emptyHearth10;
	public GameObject emptyHearthEpuise;

  
    void Update()
	{
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
