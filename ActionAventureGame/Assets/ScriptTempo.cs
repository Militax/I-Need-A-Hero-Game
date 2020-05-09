using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class ScriptTempo : MonoBehaviour
{
    public int lechiffre;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.Instance.powerState < lechiffre)
        {
            GameManager.Instance.powerState = lechiffre;
            Destroy(gameObject);
        }
    }


}