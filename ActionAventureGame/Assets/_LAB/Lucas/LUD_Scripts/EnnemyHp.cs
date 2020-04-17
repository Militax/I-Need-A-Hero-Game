using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHp : MonoBehaviour
{
    public int HP;
 
    

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            HP -= 5;
        }
        if (collision.tag == "Bullet")
        {
            HP -= 1;
        }
    }
}
