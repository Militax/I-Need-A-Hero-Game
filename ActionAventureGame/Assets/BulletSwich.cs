using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwich : MonoBehaviour
{
    bool isactive = false;
    public GameObject active;
    public GameObject inactive;
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
        if (collision.tag == "Bullet" && isactive == false)
        {
            active.SetActive(true);
            inactive.SetActive(false);
            isactive = true;
        }
        else if (collision.tag == "Bullet" && isactive == true)
        {
            inactive.SetActive(true);
            active.SetActive(false);
            isactive = false;
        }
    }
}
