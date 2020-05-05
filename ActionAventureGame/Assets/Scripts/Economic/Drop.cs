using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject[] LootTable;
    public float lootRange;
    private bool isQuitting = false;
    public int numberOfDrops;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }


    // Start is called before the first frame update
    private void OnDestroy()
    {
        if (!isQuitting)
        {
            for (int i = 0; i < numberOfDrops; i++)
            {
                int rnd = Random.Range(0, LootTable.Length);
                float range = Random.Range(-lootRange, lootRange);
                Instantiate(LootTable[rnd], gameObject.transform.position + new Vector3(range, range, 0), Quaternion.identity);
            }
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, lootRange);
    }
}
