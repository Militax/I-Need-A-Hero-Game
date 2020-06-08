using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;

public class BossLifeUI : MonoBehaviour
{
    public GameObject boss;

    public GameObject bossLife6;
    public GameObject bossLife5;
    public GameObject bossLife4;
    public GameObject bossLife3;
    public GameObject bossLife2;
    public GameObject bossLife1;


    public void Update()
    {
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 0)
        {
            bossLife1.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 3)
        {
            bossLife2.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 5)
        {
            bossLife3.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 8)
        {
            bossLife4.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 10)
        {
            bossLife5.SetActive(false);
        }
        if (boss.GetComponent<BossHealth>().CurrentBossLife <= 13)
        {
            bossLife6.SetActive(false);
        }
    }
}