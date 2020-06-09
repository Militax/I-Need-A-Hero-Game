using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxBoss : MonoBehaviour
{
    private Boss.BossComportement boss;
    private void Start()
    {
        boss = GetComponentInParent<Boss.BossComportement>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Box" || !boss.canDestroyBox) { return; }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
