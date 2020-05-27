using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuPause : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public Button FirtsButton;

    private void Start()
    {
        player = GameManager.Instance.player.gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu.activeSelf)
        {
            menu.SetActive(true);
            FirtsButton.Select();
            Time.timeScale = 0;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerPowers>().enabled = false;
            player.GetComponent<PlayerAttack>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerPowers>().enabled = true;
            player.GetComponent<PlayerAttack>().enabled = true;
        }
    }
}
