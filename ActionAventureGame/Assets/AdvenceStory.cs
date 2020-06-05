using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class AdvenceStory : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerFeet")
            {
                GameManager.Instance.NarrativeStat++;
                Destroy(gameObject);
            }
        }
    }
}