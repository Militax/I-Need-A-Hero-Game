using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
public class Key : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.HasKey = true;
        }
    }
}
