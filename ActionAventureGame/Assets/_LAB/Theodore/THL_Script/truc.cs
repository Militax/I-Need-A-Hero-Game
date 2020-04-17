using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truc : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter");
        }
        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Exit");
        }
}
