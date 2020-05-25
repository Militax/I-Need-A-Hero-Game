using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationAiguille : MonoBehaviour
{
    float timer;
    float currentTimer;
    public SwichGlobal timerSwitch;

    // Update is called once per frame
    void Update()
    {
        if (timerSwitch != null)
        {
            if (timerSwitch.IsActive)
            {
                timer = timerSwitch.timer.cooldownTime;
                currentTimer += Time.deltaTime / timer;
                float normalizedTimer = currentTimer % 1;
                gameObject.transform.eulerAngles = new Vector3(0, 0, -normalizedTimer * 360);
            }
        }
        
    }
}
