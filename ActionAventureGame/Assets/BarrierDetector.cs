using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDetector : MonoBehaviour
{
    [SerializeField]
    private Collider2D Barrier;
    [SerializeField]
    float deactivateTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("DeactivateBarrier");
    }

    IEnumerator DeactivateBarrier()
    {
        Barrier.enabled = false;
        yield return new WaitForSecondsRealtime(deactivateTime);
        Barrier.enabled = true;

    }
}
