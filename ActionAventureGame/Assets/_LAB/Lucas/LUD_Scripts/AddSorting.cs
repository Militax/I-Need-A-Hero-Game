using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSorting : MonoBehaviour
{
    private void Awake()
    {
        foreach (SpriteRenderer item in GameObject.FindObjectsOfType<SpriteRenderer>())
        {
            item.gameObject.AddComponent<PositionRendererSorter>();
        }
    }
}
