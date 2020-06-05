using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ActivationDevice[] linkedInput;
    public float firerate;
    public float speed;
    public GameObject Bullet;
    public int direction;
    public bool automatic = true;
    private bool allLinkedInputAreActive;
    private bool alreadyShootOnce;

    // Start is called before the first frame update
    void Start()
    {
        if (automatic == true)
        {
            StartCoroutine(Shoot());
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (automatic == false)
        {
            ManualActivation();
        }

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
    IEnumerator ShootOnce()
    {
        if (direction < 1 || 4 < direction) yield return null;

        GameObject bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        if (direction == 1)
        {
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.up;
        }
        else if (direction == 2)
        {
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.right;
        }
        else if (direction == 3)
        {
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.down;
        }
        else if (direction == 4)
        {
            bullet.GetComponent<Bullet>().bulletDirection = Vector2.left;
        }
        bullet.GetComponent<Bullet>().bulletSpeed = speed;
        alreadyShootOnce = true;
        yield return null;
    }
    void ManualActivation()
    {
        if (linkedInput.Length == 0)
        {
            return;
        }

        allLinkedInputAreActive = true;
        foreach (ActivationDevice item in linkedInput)
        {
            if (!item.IsActive)
            {
                allLinkedInputAreActive = false;
                alreadyShootOnce = false;
            }
        }
        if (allLinkedInputAreActive && !alreadyShootOnce)
        {
            StartCoroutine(ShootOnce());
        }
    }
}
