using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bidule : MonoBehaviour
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
}