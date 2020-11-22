using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCHange : MonoBehaviour
{
    public GameObject child;

    public void OnValueChange(string value)
    {
        if (value != string.Empty && child.activeSelf)
            child.SetActive(false);
        else if (value == string.Empty)
            child.SetActive(true);
    }
}
