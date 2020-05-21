using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pressureplatePlayer : ActivationDevice
{
    public bool stayActive = false;
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;
    
    public Vector3 eventPosition;
    public GameObject ActivateEvent;
    public GameObject DeActivateEvent;

    public GameObject ParticleSystem;
    
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(true, collision.tag); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RefreshState(false, collision.tag);
    }
    

    protected override void RefreshState(bool state, string tag = null)
    {
        foreach (Combination item in combinations)
        {

            if (item.colliderTag == tag)
            {
                if (!stayActive)
                    IsActive = !IsActive;
                else if (state)
                    IsActive = true;
                
                if (IsActive && eventObject && instance == null)
                {
                    instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
                    iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
                }
                else if (!IsActive && instance && deSpawnOnLeave)
                    Destroy(instance);
                Debug.Log(String.Format("this: {0} vs {1}", item.colliderTag, tag));
                spr.sprite = (IsActive ? item.active : item.inactive);
                if (IsActive)
                {
                    GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                    Destroy(fx, 2f);
                }
                base.RefreshState(state, tag);
                if (ActivateEvent && DeActivateEvent)
                {
                    ActivateEvent.SetActive(!ActivateEvent.activeSelf);
                    DeActivateEvent.SetActive(!DeActivateEvent.activeSelf);
                }
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (eventObject)
        {
            
            Gizmos.color = new Color(1,1,0,.2f);
            Gizmos.DrawCube(transform.position + eventPosition, new Vector3(1, 1, 0));
            Gizmos.DrawLine(transform.position , transform.position + eventPosition);
        }

    }
}
