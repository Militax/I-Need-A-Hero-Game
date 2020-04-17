using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGingerbreadBehaviour : MonoBehaviour
{
    private float damage;
    public float Damage { set { damage = value; } }
    private bool canAttack = false;
    private Collider2D myCollider;
    private Collider2D player;
    private void Awake()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        myCollider.enabled = true;
        canAttack = true; 
        if (player)
            OnTriggerStay2D(player);
        StartCoroutine("Disapear");
    }
    IEnumerator Disapear()
    {
        //Debug.Log("will desapear");
        yield return new WaitForSeconds(1f);
        //Debug.Log("desapear");
        myCollider.enabled = false;
        gameObject.SetActive(false);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag + " _ " + canAttack);
        if (other.tag != "Player") { return; }
        player = other;
        if (canAttack)
        {
            other.GetComponent<Playerdemerdenonofficiel>().health -= damage;
            canAttack = false;
        }

    }

}
