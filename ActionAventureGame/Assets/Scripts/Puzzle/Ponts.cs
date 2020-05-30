using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponts : MonoBehaviour
{
    public ActivationDevice[] linkedInput;
    public bool startState = false;

    public Material material;
    public bool isDissolving = false;
    public float fade;


    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        //bool state = startState;

        //if (linkedInput.Length == 0)
        //{
        //return;
        //}
        //if (isDissolving && stayActive)
        //    return;

        //foreach (ActivationDevice item in linkedInput)
        //{
        //    if (!item.IsActive)
        //    {
        //        state = !startState;
        //    }
        //}

        //isDissolving = !state;

       foreach (ActivationDevice item in linkedInput)
        {
            if (!item.IsActive)
            {
                fade = Time.deltaTime;

                if (fade <= 0f)
                {
                    fade = 0f;
                    isDissolving = false;
                }

                material.SetFloat("DissolveAmount", fade);
            }
        }

        //if (material == null)
        //{
        //    material = GetComponent<SpriteRenderer>().material;
        //}
    }
}
