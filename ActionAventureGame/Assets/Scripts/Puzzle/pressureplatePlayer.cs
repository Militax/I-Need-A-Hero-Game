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
    
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(true, collision.tag); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RefreshState(false, collision.tag);
    }
    //private void checkActivity(string Tag,bool active)
    //{
        
    //    foreach (Combination item in combinations)
    //    {
            
    //        if (item.colliderTag == Tag)
    //        {
    //            if (active && eventObject && instance == null)
    //            {
    //                instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
    //                iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
    //            }
    //            else if (!active && instance && deSpawnOnLeave)
    //                Destroy(instance);
    //            Debug.Log(String.Format("this: {0} vs {1}", item.colliderTag, Tag));
    //            spr.sprite = (active ? item.active : item.inactive);
    //            alreadyPressed = true;
    //            ActivateEvent.SetActive(true);
    //            DeActivateEvent.SetActive(false);
    //            break;
    //        }
    //    }
    //}
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
