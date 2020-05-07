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
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.up;
            bullet.GetComponent<Bullet>().bulletSpeed = speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 2)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.right;
            bullet.GetComponent<Bullet>().bulletSpeed = speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 3)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.down;
            bullet.GetComponent<Bullet>().bulletSpeed = speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }
        if (direction == 4)
        {
            GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.left;
            bullet.GetComponent<Bullet>().bulletSpeed = speed;
            yield return new WaitForSeconds(firerate);
            StartCoroutine(Shoot());
        }

    }
}
