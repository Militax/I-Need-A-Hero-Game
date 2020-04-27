using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{
    public class WindPart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }
        }

    }
}