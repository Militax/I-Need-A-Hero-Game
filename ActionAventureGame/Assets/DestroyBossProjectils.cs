using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossProjectils : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("LightBullet")) { return; }
        if(transform.position.y>collision.transform.position.y)GameObject.Destroy(collision.gameObject);
    }
}
