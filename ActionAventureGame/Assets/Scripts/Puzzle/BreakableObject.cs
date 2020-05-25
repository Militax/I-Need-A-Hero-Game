using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class BreakableObject : MonoBehaviour
{
    [Header("Loot")]
    public int dropNumber;
    public int lootRange;
    public GameObject[] myLoot;
    //GameManager.Instance.loot(dropNumber, lootRange, myLoot);




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            GameManager.Instance.loot(dropNumber, lootRange, myLoot, this.gameObject);
            Destroy(gameObject);
        }
    }
}
