using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanBox : MonoBehaviour
{
    public GameObject box;
    public GameObject linkedInput;
    bool activateonce = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (linkedInput.activeSelf)
        {
            activate();
        }
        else if (!linkedInput.activeSelf)
        {
            activateonce = true;
        }
    }
    void activate()
    {
        if (activateonce == true)
        {
            Instantiate(box, gameObject.transform.position, Quaternion.identity);
            activateonce = false;
        }
        
    }
}
