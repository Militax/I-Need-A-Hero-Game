using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SortingonSpawn : MonoBehaviour
{
    
    public float offset;
    [HideInInspector]
    public List<float> HeightMap = new List<float>();
    SpriteRenderer spr;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        DynamicSort();
        HeightMap = FindObjectOfType<AddSorting>().Allitems.Select(i => i.offset).ToList();
    }
    private void DynamicSort()
    {
        float current = transform.position.y - offset;
        for (int i = 0; i < HeightMap.Count; i++)
        {
            if (current > HeightMap[i])
            {
                spr.sortingOrder = i;
                return;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, offset, 0), 0.02f);
    }
}
