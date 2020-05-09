using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddSorting : MonoBehaviour
{
   public class rendererDescriptor
    {
        public float offset;
        public SpriteRenderer spr;
    }
    [HideInInspector]
    public List<rendererDescriptor> Allitems = new List<rendererDescriptor>();
    
    
    private void Start()
    {
        Allitems.Clear();

        foreach (SpriteRenderer item in GameObject.FindObjectsOfType<SpriteRenderer>())
        {
            Allitems.Add(new rendererDescriptor() {offset = item.transform.position.y - item.bounds.size.y / 2, spr = item});
            //if (item.GetComponent<PositionRendererSorter>())
            //{
            //    foreach (PositionRendererSorter p in item.GetComponents<PositionRendererSorter>())
            //    {
            //        DestroyImmediate(p);
            //    }

            //}

            //var comp = item.gameObject.AddComponent<PositionRendererSorter>();
            //comp.sort();


        }
        Allitems = Allitems.OrderByDescending(t => t.offset).ToList();
        for (int i = 0; i < Allitems.Count; i++)
        {
            Allitems[i].spr.sortingOrder = i;
        }
        foreach (DynamicSorting item in GameObject.FindObjectsOfType<DynamicSorting>())
        {
            item.HeightMap = Allitems.Select(i => i.offset).ToList();
        }

    }
    private void OnDrawGizmos()
    {
        if (Allitems.Count == 0)
        {
            return;
        }

        Gizmos.color = Color.red;
        foreach (rendererDescriptor item in Allitems)
        {
            Gizmos.DrawWireSphere(new Vector2(item.spr.transform.position.x,item.offset), 0.01f);
        }


    }
    
}
