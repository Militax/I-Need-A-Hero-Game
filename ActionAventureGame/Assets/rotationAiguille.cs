using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationAiguille : MonoBehaviour
{
    public GameObject aiguille;
    float timer;
    float currentTimer;
    public SwichGlobal timerSwitch;

    [Header("Audio")]
    public AudioClip timerAudio;
    public bool canPlay = true;

    // Update is called once per frame
    void Update()
    {
        if (timerSwitch != null)
        {
            if (timerSwitch.IsActive)
            {
                if (canPlay)
                {
                    StartCoroutine(SoundDuration());
                }

                foreach (Image item in GetComponentsInChildren<Image>())
                {
                    item.enabled = true;
                }
                timer = timerSwitch.timer.cooldownTime;
                currentTimer += Time.deltaTime / timer;
                float normalizedTimer = currentTimer % 1;
                aiguille.transform.eulerAngles = new Vector3(0, 0, -normalizedTimer * 360);
                
            }
            else
            {
                foreach (Image item in GetComponentsInChildren<Image>())
                {
                    item.enabled = false;
                }
            }
        }
        else
        {
            foreach (Image item in GetComponentsInChildren<Image>())
            {
                item.enabled = false;
            }
             
        }
        
    }



    IEnumerator SoundDuration()
    {
        SoundManager.instance.PlaySfx(timerAudio, 3, 1);
        canPlay = false;
        yield return new WaitForSeconds(20);
        canPlay = true;
    }
}
