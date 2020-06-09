using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponts : MonoBehaviour
{
    public ActivationDevice[] linkedInput;

    public Material material;
    public float DissolveAmount;
    bool appeared = false;



    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("DissolveAmount", 0);
    }
    void FixedUpdate()
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


                if (DissolveAmount < 1 && appeared == false)
                {
                    material.SetFloat("DissolveAmount", DissolveAmount);

                    DissolveAmount += 0.010f;
                }
                if (DissolveAmount >= 1)
                {
                    appeared = true;
                }
            }
            if (appeared == true && !item.IsActive)
            {
                
                if (DissolveAmount > 0)
                {

                    material.SetFloat("DissolveAmount", DissolveAmount);

                    DissolveAmount -= 0.010f;
                }
                if (DissolveAmount <= 0)
                {
                    appeared = false;
                }

            }
        }


    }
}
