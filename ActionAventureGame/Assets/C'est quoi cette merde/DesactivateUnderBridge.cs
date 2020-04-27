using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateUnderBridge : MonoBehaviour
{
    public GameObject SupressedWater;
    // Start is called before the first frame update
    void Start()
    {
        SupressedWater.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
