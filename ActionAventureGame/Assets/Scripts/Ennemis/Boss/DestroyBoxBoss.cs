using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxBoss : MonoBehaviour
{
    private Boss.BossComportement boss;
    private void Start()
    {
        boss = GetComponentInParent<Boss.BossComportement>();
        Debug.Log("Start DestroyBoxBoss script");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.gameObject.name + " canDestroy: "+ boss.canDestroyBox);
        if (other.gameObject.tag != "Box" || !boss.canDestroyBox) { return; }
        Debug.Log("Destroy Box !");
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
