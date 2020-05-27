using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
using UnityEngine.UI;

public class SaveReference : MonoBehaviour
{
    public GameObject SavePrefab;
    public void LoadSaves()
    {
        for (int i = 0; i < SaveDictionary.GetAllSaves().Length; i++)
        {
            Instantiate(SavePrefab, transform.position,Quaternion.identity);
            SavePrefab.GetComponentInChildren<Text>().text = SaveDictionary.GetAllSaves()[i];
        }
    }
    
}
