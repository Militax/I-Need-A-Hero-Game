using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class OneWayWall : MonoBehaviour
{
    Transform player;
    Collider2D collider;
    [Tooltip ("TOP,BOTTOM,RIGHT,LEFT")]
    public string side;
    public float offsetY;
    public float offsetX;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        Side();
    }

    void Side()
    {
        switch (side)
        {
            case ("TOP"):
                if (player.transform.position.y > gameObject.transform.position.y)
                {
                    collider.enabled = false;
                }
                else
                {
                    collider.enabled = true;
                }
                break;

            case ("BOTTOM"):
                if (player.transform.position.y <= gameObject.transform.position.y)
                {
                    collider.enabled = false;
                }
                else
                {
                    collider.enabled = true;
                }
                break;
            case ("RIGHT"):
                if (player.transform.position.x > gameObject.transform.position.x+ offsetX)
                {
                    collider.enabled = false;
                }
                else
                {
                    collider.enabled = true;
                }
                break;
            case ("LEFT"):
                if (player.transform.position.x <= gameObject.transform.position.x + offsetX)
                {
                    collider.enabled = false;
                }
                else
                {
                    collider.enabled = true;
                }
                break;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position + new Vector3(0,offsetY,0),0.02f);
        Gizmos.DrawWireSphere(gameObject.transform.position + new Vector3(offsetX,0,0),0.02f);
    }
}
