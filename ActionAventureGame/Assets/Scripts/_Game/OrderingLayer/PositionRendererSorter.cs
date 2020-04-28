using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int Order = 2000;
    [SerializeField]
    public float offset = 0;
    public bool runOnce = false;
    float timer;
    float timerMax = .1f;
    private Renderer myRenderer;
    AddSorting addSorting;
    List<GameObject> Allitems;



    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {

        sort();
        
    }
    public void sort()
    {
        addSorting = GameObject.FindObjectOfType<AddSorting>();
        
        //timer -= Time.deltaTime;
        //if (timer <= 0f)
        //{
        if (!myRenderer)
        {
            myRenderer = GetComponent<Renderer>();
        }
        //    timer = timerMax;
        offset = myRenderer.bounds.size.y / 2;
        //    if (offset <= .5f)
        //        offset = 1;
        //    myRenderer.sortingOrder = (int)(Order - transform.position.y - offset);
        //    if (runOnce)
        //        Destroy(this);
        //}
        Allitems = Allitems.OrderByDescending(t => t.transform.position.y - offset).ToList();
        foreach (GameObject G in Allitems)
        {
            G.GetComponent<Renderer>().sortingOrder = addSorting.numberOfLayers;
            

        }
        addSorting.numberOfLayers += 1;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    if (!myRenderer)
    //    {
    //        myRenderer = GetComponent<Renderer>();
    //    }
    //    offset = (int)myRenderer.bounds.size.y/2;
    //    Gizmos.DrawWireSphere(transform.position - new Vector3(0,offset,0), 0.01f);

    //}
}
