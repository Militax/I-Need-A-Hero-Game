using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnnemiesWavesManagers : MonoBehaviour
{
    private GameObject[] waves;
    private int activeWaveID = 0;
    private BossEnnemiesWave activeEnnemiesWave;
    // Start is called before the first frame update
    void Start()
    {
        waves = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            waves[i] = transform.GetChild(i).gameObject;
            if (i == 0)
            {
                waves[i].SetActive(true);
                activeEnnemiesWave = waves[i].GetComponent<BossEnnemiesWave>();
            }
            else waves[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWaveID < transform.childCount-1)
        {
            if (activeEnnemiesWave.isWaveEmpty)
            {
                waves[activeWaveID].SetActive(false);
                activeWaveID++;
                waves[activeWaveID].SetActive(true);
                activeEnnemiesWave = waves[activeWaveID].GetComponent<BossEnnemiesWave>();
            }
        }
        else return;
    }
}
