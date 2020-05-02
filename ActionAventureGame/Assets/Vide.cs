using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vide : MonoBehaviour
{

    public string[] ennemyTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Fall(other.tag,other.gameObject);
    }
    
    void Fall(string tag,GameObject ennemy)
    {
        foreach (string item in ennemyTags)
        {
            if (item == tag)
            {
                Destroy(ennemy);
            }
        }
    }
}
