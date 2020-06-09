using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;

public class pressureplatePlayer : ActivationDevice
{
    public bool stayActive = false;
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;
    
    public Vector3 eventPosition;
    public GameObject ActivateEvent;
    public GameObject DeActivateEvent;

    public bool WasActivated;
    public GameObject ParticleSystem;

    private PlayableDirector Timeline;
    public GameObject TimelineDirector;
    public bool timelineNeeded;
    private bool timelinePlayed;

    [Header("Audio")]
    public AudioClip pressurePlateAudio;

    public void Start()
    {
        timelinePlayed = false;
        if (timelineNeeded == true)
        {
            Timeline = TimelineDirector.GetComponent<PlayableDirector>();
        }
    }

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
                if (timelineNeeded == true && timelinePlayed == false)
                {
                    Timeline.Play();
                    timelinePlayed = true;
                }

                if (!stayActive)
                {
                    IsActive = !IsActive;
                }
                else if (state)
                {
                    IsActive = true;
                  
                }          

                if (IsActive && eventObject && instance == null)
                {
                    instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
                    iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
                   

                }
                else if (!IsActive && instance && deSpawnOnLeave)
                    Destroy(instance);
                //Debug.Log(String.Format("this: {0} vs {1}", item.colliderTag, tag));
                spr.sprite = (IsActive ? item.active : item.inactive);
                if (stayActive)
                {
                    if (IsActive && !WasActivated)
                    {
                        WasActivated = true;
                        Debug.Log("Play the fucking sound");
                        SoundManager.instance.PlaySfx(pressurePlateAudio, 1, 1);
                        GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);

                        Destroy(fx, 2f);
                    }
                }
                else if (!stayActive)
                {
                    if (IsActive)
                    {
                        Debug.Log("Play the fucking sound");
                        SoundManager.instance.PlaySfx(pressurePlateAudio, 1, 1);
                        GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                        Destroy(fx, 2f);
                    }
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
