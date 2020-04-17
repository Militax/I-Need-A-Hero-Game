using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    /// <summary>
    /// Theodore Labyt
    /// 
    /// Gère la destruction d'objet par l'épée'
    /// </summary>
public class DestructibleObejctSword : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword"))
            {
                Destroy(gameObject);
            }
        }

    }
}
