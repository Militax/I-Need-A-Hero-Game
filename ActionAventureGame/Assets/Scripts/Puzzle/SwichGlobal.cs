using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SwichGlobal : ActivationDevice
{
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;

    public Vector3 eventPosition;
    //public GameObject ActivateEvent;
    //public GameObject DeActivateEvent;
    public bool SwitchOnce;
    public bool canSwitch = true;
    public bool useTimer;
    public float timer;
    Cooldown activationCooldown = new Cooldown(0.5f);

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (activationCooldown.IsOver())
        {
            if (HasBeenActivated && SwitchOnce)
            {
                return;
            }
            activationCooldown.Reset();
            Debug.Log(other.tag + " " + gameObject.name);
            RefreshState(!IsActive, other.tag);

            if (useTimer)
                StartCoroutine(Timer());

        }


    }




    protected override void RefreshState(bool state, string tag = null)
    {

        foreach (Combination item in combinations)
        {

            if (item.colliderTag == tag)
            {

                current = item;
                IsActive = state;

                if (IsActive && eventObject && instance == null)
                {
                    instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
                    iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
                }

                else if (!IsActive && instance && deSpawnOnLeave)
                    Destroy(instance);

                spr.sprite = (IsActive ? item.active : item.inactive);
                base.RefreshState(state, tag);
                //if (!ActivateEvent || !DeActivateEvent)
                //    return;
                //ActivateEvent.SetActive(!ActivateEvent.activeSelf);
                //DeActivateEvent.SetActive(!DeActivateEvent.activeSelf);


                break;
            }
            if (SwitchOnce)
                canSwitch = false;

        }
        foreach (ActivationDevice item in interactables)
        {
            if (IsActive)
            {
                item.enabled = true;
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (!IsActive)
            {
                item.GetComponent<SwichGlobal>().RefreshState(false, current.colliderTag);
                item.enabled = false;
                item.GetComponent<SpriteRenderer>().enabled = false;
            }

        }

    }
    private void OnDrawGizmos()
    {
        if (eventObject)
        {

            Gizmos.color = new Color(1, 1, 0, .2f);
            Gizmos.DrawCube(transform.position + eventPosition, new Vector3(1, 1, 0));
            Gizmos.DrawLine(transform.position, transform.position + eventPosition);
        }

    }



    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        RefreshState(!IsActive, current.colliderTag);
    }

    private void Awake()
    {
        if (interactables.Length != 0)
        {
            foreach (ActivationDevice item in interactables)
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
                item.enabled = false;
            }
        }
    }
}
