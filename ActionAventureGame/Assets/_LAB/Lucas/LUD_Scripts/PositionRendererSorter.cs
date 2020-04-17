using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int Order = 2000;
    [SerializeField]
    private int offset = 0;
    public bool runOnce = false;
    float timer;
    float timerMax = .1f;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(Order - transform.position.y - offset);
            if (runOnce)
                Destroy(this);
        }
        
    }
}
