using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCheck : MonoBehaviour
{
    public string[] SafeColliders;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponentInParent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string item in SafeColliders)
        {
            if (item == collision.tag)
            {
                collider.isTrigger = false;
            }
            else
            {
                collider.isTrigger = true;
            }
        }
    }
}
