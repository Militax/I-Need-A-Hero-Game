using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHp : MonoBehaviour
{
    public int DamageTaken;
    public int currentHP;
    public int MaxHP;
    Animator animator;
    public GameObject ParticleSystem;
    bool die = false;
    public int TimerDie;
    bool takedamage;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        animator = gameObject.GetComponent<Animator>();
        takedamage = GetComponent<catBehaviour>().canBeDamaged;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            gameObject.GetComponent<catBehaviour>().StopAllCoroutines();
            gameObject.GetComponent<catBehaviour>().enabled = false;
            animator.SetTrigger("Death");
            StartCoroutine(cooldown());
            if (die)
            {
                Destroy(gameObject);
            }
        }

        takedamage = GetComponent<catBehaviour>().canBeDamaged;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            animator.SetTrigger("Degat");
            GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
            Destroy(fx, 1f);

            if (takedamage)
            {
                
                animator.SetBool("CanDamaged", true);
                currentHP -= DamageTaken;
            }
            if (!takedamage)
            {
                
                animator.SetBool("CanDamaged", false); //animation parade
            }
        }
        if (other.tag == "WindWave")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }


    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(TimerDie);
        die = true;
    }
}
