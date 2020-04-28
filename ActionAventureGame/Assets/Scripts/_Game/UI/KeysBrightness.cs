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
    private Marchand marchand;

    private void Awake()
    {
        marchand = GameObject.FindObjectOfType<Marchand>();
    }


    // Update is called once per frame
    void Update()
    {
        foreach (KeyDescriptor keyDescriptor in Keys)
        {
            if (keyDescriptor.dependsOnShop)
            {
                keyDescriptor.reference.color = (!marchand.CanEnterShop ? pressedColor : defaultColor);
                continue;
            }
            keyDescriptor.reference.color = (Input.GetButton(keyDescriptor.KeyInput) ? pressedColor : defaultColor);
        }
    }
}
