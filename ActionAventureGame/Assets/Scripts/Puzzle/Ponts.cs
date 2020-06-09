using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponts : MonoBehaviour
{
    public ActivationDevice[] linkedInput;

    public Material material;
    public float DissolveAmount;
    bool appeared = false;

    [Header("Audio")]
    public AudioClip pontAudio1;
    public AudioClip pontAudio2;

    bool havePlay = false;


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
                    if (!havePlay)
                    {
                        PlayPontSound();
                    }

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





    void PlayPontSound()
    {
        int index = Random.Range(1, 3);

        switch(index)
        {
            case (1):
                SoundManager.instance.PlaySfx(pontAudio1, 1, 1);
                break;

            case (2):
                SoundManager.instance.PlaySfx(pontAudio2, 1, 1);
                break;
        }

        StartCoroutine(SoundCoolDown());
    }

    IEnumerator SoundCoolDown()
    {
        havePlay = true;
        yield return new WaitForSeconds(3);
        havePlay = false;
    }
}
