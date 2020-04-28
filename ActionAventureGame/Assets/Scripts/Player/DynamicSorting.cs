using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSorting : MonoBehaviour
{
    Cooldown cd = new Cooldown(.2f);
    public float offset;
    [HideInInspector]
    public List<float> HeightMap = new List<float>();
    SpriteRenderer spr;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
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
    private void LateUpdate()
    {
        if (cd.IsOver())
        {
            cd.Reset();
            DynamicSort();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, offset, 0),0.02f);
    }
}
