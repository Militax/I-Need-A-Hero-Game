using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class teleporter : MonoBehaviour
{
    [System.Serializable]
    public class Tele
    {
        public GameObject teleporter;
        public string tpKey;
    }
    public Tele[] teleports;



    private void Update()
    {
        foreach (Tele item in teleports)
        {
            if (Input.GetKey(item.tpKey))
            {
                GameManager.Instance.player.transform.position = item.teleporter.transform.position;
            }
        }
    }
            
        
   
}
