using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class BossEnnemiesWave : MonoBehaviour
{
    public bool isWaveEmpty = false;
    [SerializeField]
    private GameObject ennemies;
    // Start is called before the first frame update
    void Start()
    {
        if (ennemies == null)
        {
            ennemies = transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isWaveEmpty = ennemies.transform.childCount <= 0;
    }
}
