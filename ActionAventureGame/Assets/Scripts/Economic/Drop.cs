using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject[] LootTable;
    public float lootRange;
    private bool isQuitting = false;
    public int numberOfDrops;
    bool canLoot = true;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void open()
    {
        if (canLoot == true)
        {
            for (int i = 0; i < numberOfDrops; i++)
            {
                int rnd = Random.Range(0, LootTable.Length);
                float range = Random.Range(-lootRange, lootRange);
                Instantiate(LootTable[rnd], gameObject.transform.position + new Vector3(range, range, 0), Quaternion.identity);
            }
            canLoot = false;
        }
        
    }
    // Start is called before the first frame update
    private void OnDestroy()
    {
        if (!isQuitting && canLoot == true)
        {
            for (int i = 0; i < numberOfDrops; i++)
            {
                int rnd = Random.Range(0, LootTable.Length);
                float range = Random.Range(-lootRange, lootRange);
                Instantiate(LootTable[rnd], gameObject.transform.position + new Vector3(range, range, 0), Quaternion.identity);
            }
            canLoot = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButton("Interaction"))
            {
                open();
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, lootRange);
    }
}
