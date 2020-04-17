using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnnemyShot;
    public Vector2 ShotPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShotPos = Player.transform.position - gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("adad");
            
            Shooting();
        }
    }
    void Shooting()
    {
        GameObject Bullet = Instantiate(EnnemyShot, gameObject.transform.position, Quaternion.identity);
        Bullet.AddComponent<Rigidbody2D>();
        
        Bullet.GetComponent<Rigidbody2D>().AddForce(ShotPos * speed, ForceMode2D.Impulse);
        Bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
