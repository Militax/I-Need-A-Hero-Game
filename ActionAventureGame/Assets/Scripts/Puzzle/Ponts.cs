using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponts : MonoBehaviour
{
    public ActivationDevice[] linkedInput;

    public Material material;
    public float DissolveAmount;
    int AllActive = 0;


    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("DissolveAmount", 0);
    }
    void Update()
    {
        int AllActive = 0;

        foreach (ActivationDevice item in linkedInput)
        {

            if (item.IsActive)
            {
                AllActive++;
            }

            if (AllActive >= linkedInput.Length)
            {
                if (DissolveAmount < 1)
                {
                    material.SetFloat("DissolveAmount", DissolveAmount);

                    DissolveAmount += 0.004f;
                }
            }
        }

    
    }
}
