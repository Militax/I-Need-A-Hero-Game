using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


public class RepawnManager : MonoBehaviour
{
    public GameObject acces;
    public GameLoader loader;

    void Start()
    {
        if (GameManager.Instance.isComingFromDonjon == true)
        {
            GameManager.Instance.player.gameObject.transform.position = this.transform.position;
            acces.SetActive(true);
            loader.SaveGame(loader.saveName);
        }
    }
}
