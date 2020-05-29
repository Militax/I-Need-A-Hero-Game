using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
public class CheckPointVide : MonoBehaviour
{
    public Vector3 NewRespawnPoint;

    private void Start()
    {
        NewRespawnPoint = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFeet")
            GameManager.Instance.RespawnPointVide = NewRespawnPoint;
    }
}
