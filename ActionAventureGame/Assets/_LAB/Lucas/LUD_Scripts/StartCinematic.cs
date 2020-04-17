using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class StartCinematic : MonoBehaviour
{
    bool runOnce = false;
    Rigidbody2D rb;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject anim;
    public GameObject player;
    public int cinematicDuration;
    public int travelTime; //( toujous 1/3 de cinematic duration )
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && runOnce == false)
        {
            runOnce = true;
            rb.bodyType = RigidbodyType2D.Static;
            cam2.SetActive(true);
            cam1.SetActive(false);
            StartCoroutine(CinematicDuration());
            StartCoroutine(StartAnim());
        }
    }
    IEnumerator CinematicDuration()
    {
        yield return new WaitForSeconds(cinematicDuration);
        cam1.SetActive(true);
        cam2.SetActive(false);
        anim.SetActive(false);
        yield return new WaitForSeconds(travelTime);
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(travelTime);
        anim.SetActive(true);
    }
}
