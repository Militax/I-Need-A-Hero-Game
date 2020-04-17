using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    /// <summary>
    /// Matis Duperray
    /// 
    /// Gère la destruction d'objet par le vent
    /// </summary>
    public class DestructibleObject : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                Destroy(gameObject);
            }
        }

    }
}