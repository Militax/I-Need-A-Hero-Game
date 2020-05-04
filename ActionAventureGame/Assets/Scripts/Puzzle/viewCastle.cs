using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class viewCastle : MonoBehaviour
{

    public Camera maincam;
    public Camera ViewChateau;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ViewChateau.enabled = true;
            maincam.enabled = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            maincam.enabled = true;
            ViewChateau.enabled = false;
        }

    }
    private void Start()
    {
        ViewChateau.enabled = false;
    }
}
