using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSwich : MonoBehaviour
{
    
    public GameObject active;
    public GameObject inactive;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            active.SetActive(true);
            inactive.SetActive(false);
            StartCoroutine(Timer());
        }
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        active.SetActive(false);
        inactive.SetActive(true);
    }
}
