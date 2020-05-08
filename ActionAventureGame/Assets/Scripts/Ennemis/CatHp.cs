using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHp : MonoBehaviour
{
    public int DamageTaken;
    public int currentHP;
    public int MaxHP;
    Animator animator;
    bool die = false;
    public int TimerDie;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            animator.SetTrigger("Death");
            StartCoroutine(cooldown());
            if(die)
            {
                Destroy(gameObject);
            }
        }
           
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            animator.SetTrigger("Degat");
            currentHP -= DamageTaken;
        }
        if (other.tag == "WindWave")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(TimerDie);
        die = true;
    }
}
