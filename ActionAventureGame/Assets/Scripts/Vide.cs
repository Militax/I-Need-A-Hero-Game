using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class Vide : MonoBehaviour
{
   public Vector3 RepopPos;
    public string[] ennemyTags;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Fall(other.tag, other.gameObject);
    }

    void Fall(string tag, GameObject ennemy)
    {
        foreach (string item in ennemyTags)
        {
            if (item == tag)
            {
                if (tag == "PlayerFeet")
                {
                    ennemy.transform.position = transform.position + RepopPos;
                    return;
                }
                if (tag == "Box")
                {

                    GameObject newBox = Instantiate(ennemy,transform.position + RepopPos, Quaternion.identity);
                    print(ennemy);
                }
                if (ennemy.tag != "PlayerFeet")
                {
                    Destroy(ennemy);
                }
                
            }
        }
    }
    private void OnDrawGizmos()
    {


        Gizmos.color = new Color(1, 1, 0, .2f);
        Gizmos.DrawCube(transform.position + RepopPos, new Vector3(1, 1, 0));
        Gizmos.DrawLine(transform.position, transform.position + RepopPos);


    }
}
