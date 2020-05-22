using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class KeysBrightness : MonoBehaviour
{
    [System.Serializable]
    public class KeyDescriptor
    {
        public string KeyInput;
        public Image reference;
        public bool dependsOnShop;
        public bool usesPowerState;
        public bool notUsed;
    }
    public KeyDescriptor[] Keys;
    public Color pressedColor;
    public Color defaultColor;

    
    public Marchand marchand;


    // Update is called once per frame
    void Update()
    {
        foreach (KeyDescriptor keyDescriptor in Keys)
        {
            if (marchand != null)
            {
                
                if (keyDescriptor.dependsOnShop)
                {
                    keyDescriptor.reference.color = (!marchand.CanEnterShop ? pressedColor : defaultColor);
                    
                }
                else if (keyDescriptor.usesPowerState && GameManager.Instance.powerState < 1)
                {
                    keyDescriptor.reference.color = pressedColor;
                }
                else if (keyDescriptor.notUsed)
                {
                    keyDescriptor.reference.color = pressedColor;
                }
                else
                {
                    keyDescriptor.reference.color = (Input.GetButton(keyDescriptor.KeyInput) ? pressedColor : defaultColor);
                }
                
                //continue;
                
            }
            
            
        }
    }
}
