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
    


    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFeet")
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
}
