﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleSwiches : ActivationDevice
{

    public doubleSwiches other;

    protected override void RefreshState(bool state, string tag = null)
    {
        foreach (Combination item in combinations)
        {
            if (item.colliderTag == tag)
            {
                current = item;
                IsActive = state;
                spr.sprite = (IsActive ? item.active : item.inactive); // (Ternaire) si IsActive = true : vert else :rouge
                if (tag != null && other.IsActive == this.IsActive)
                {
                    Debug.Log("hoho");
                    other.RefreshState(!IsActive, current.colliderTag);
                }

                base.RefreshState(state, tag);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(!IsActive, collision.tag);
    }
}
