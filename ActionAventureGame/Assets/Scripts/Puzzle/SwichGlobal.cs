using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
public class SwichGlobal : ActivationDevice
{
    Combination registered = null;
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;

    public Vector3 eventPosition;
    //public GameObject ActivateEvent;
    //public GameObject DeActivateEvent;
    public bool SwitchOnce;
    [HideInInspector]
    public bool canSwitch = true;
    public bool useTimer;
    //public float timer;
    Cooldown activationCooldown = new Cooldown(0.5f);
    public Cooldown timer;

    public GameObject FirePit;
    private PlayableDirector Timeline;
    public bool TimelineNeeded;
    Animator animator;
    public GameObject ParticleSystem;
    public float OffsetParticle;
    public float RotationParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (activationCooldown.IsOver())
        {
            if ((HasBeenActivated && SwitchOnce) || (useTimer && !timer.isStopped) )
            {
                return;
            }
            activationCooldown.Reset();
            Debug.Log(other.tag + " " + gameObject.name);
            RefreshState(!IsActive, other.tag);

            //if (useTimer)
            //{
            //    registered = current;
            //    timer.Reset();
            //}
                

        }


    }

    private void Start()
    {
        if (spr == null)
        {
            spr = GetComponent<SpriteRenderer>();
        }
        timer.isStopped = true;

        if (TimelineNeeded == true)
        {
            Timeline = FirePit.GetComponent<PlayableDirector>();
        }
          
    }

    private void Update()
    {
        if (timer.IsOver() && !timer.isStopped)
        {
            RefreshState(!IsActive, registered.colliderTag);
            timer.isStopped = true;
            
        }

        animator = gameObject.GetComponent<Animator>();
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

                    if (TimelineNeeded == true)
                    {
                        Timeline.Play();
                    }
                }

                else if (!IsActive && instance && deSpawnOnLeave)
                    Destroy(instance);
                Debug.Log(item.colliderTag);
                //spr.sprite = (IsActive ? item.active : item.inactive);
                if (IsActive)
                {
                    animator.SetTrigger("ToActive");
                    GameObject fx = Instantiate(ParticleSystem, this.transform.position + new Vector3 (0,OffsetParticle,0), Quaternion.Euler(RotationParticle,0,0));
                    Destroy(fx, 2f);
                }
                else if (!IsActive)
                {
                    animator.SetTrigger("ToInactive");
                    GameObject fx = Instantiate(ParticleSystem, this.transform.position + new Vector3(0, OffsetParticle, 0), Quaternion.Euler(RotationParticle,0,0));
                    Destroy(fx, 2f);
                }
                base.RefreshState(state, tag);
                //if (!ActivateEvent || !DeActivateEvent)
                //    return;
                //ActivateEvent.SetActive(!ActivateEvent.activeSelf);
                //DeActivateEvent.SetActive(!DeActivateEvent.activeSelf);
                if (useTimer && timer.isStopped)
                {
                    registered = current;
                    timer.Reset();
                }

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