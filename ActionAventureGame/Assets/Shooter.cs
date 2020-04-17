using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float firerate;
    public float speed;
    public GameObject Bullet;
    public int direction;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Shoot()
    {
        if (direction == 1)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up* speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 2)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 3)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 4)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }

    }
}
