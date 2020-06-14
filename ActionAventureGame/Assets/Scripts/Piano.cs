using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{

    public AudioClip INeedAHeroPiano;
    public GameObject startInputShop;
    public bool canPlay = false;
    public bool isPlaying = false;
    float cooldownMusic = 45;

   


    private void Update()
    {
        if (canPlay && !isPlaying)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                SoundManager.instance.PlayMusic(INeedAHeroPiano, 0.5f);
                isPlaying = true;
                StartCoroutine(cooldown());
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerFeet")
        {
            canPlay = true;
            startInputShop.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerFeet")
        {
            canPlay = false;
            startInputShop.SetActive(false);

        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cooldownMusic);
        isPlaying = false;
    }
}
