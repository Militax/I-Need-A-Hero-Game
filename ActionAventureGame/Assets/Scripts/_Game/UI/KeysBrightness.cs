using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysBrightness : MonoBehaviour
{
    [System.Serializable]
    public class KeyDescriptor
    {
        public string KeyInput;
        public Image reference;
        public bool dependsOnShop;
    }
    public KeyDescriptor[] Keys;
    public Color pressedColor;
    public Color defaultColor;

    [HideInInspector]
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
                continue;
            }
            keyDescriptor.reference.color = (Input.GetButton(keyDescriptor.KeyInput) ? pressedColor : defaultColor);
        }
    }
}
