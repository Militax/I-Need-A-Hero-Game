using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class teleporter : MonoBehaviour
{
    public GameObject tpcastle;
    public string tpCastleKey;
    public GameObject tpstart;
    public string tpStartKey;
    public GameObject tpvillage;
    public string tpVillageKey;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFeet")
        {
            if (Input.GetKeyDown(tpCastleKey))
            {
                GameManager.Instance.player.gameObject.transform.position = tpcastle.transform.position;
            }
            else if (Input.GetKeyDown(tpStartKey))
            {
                GameManager.Instance.player.gameObject.transform.position = tpstart.transform.position;
            }
            else if (Input.GetKeyDown(tpVillageKey))
            {
                GameManager.Instance.player.gameObject.transform.position = tpvillage.transform.position;
            }
        }
    }
}
