using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoublePlates : ActivationDevice
{
    public GameObject ParticleSystem;
    public DoublePlates other;


    private PlayableDirector Timeline;
    public bool TimelineNeeded;
    private bool TimelinePlayed;

    public void Start()
    {
        if (TimelineNeeded == true)
        {
            Timeline = GetComponent<PlayableDirector>();
        }

        TimelinePlayed = false;
    }

    private void Update()
    {
        GetComponent<Collider2D>().enabled = !IsActive;
    }
    public override void RefreshState(bool state, string tag = null)
    {
        foreach (Combination item in combinations)
        {
            if (item.colliderTag == tag)
            {
                if(TimelineNeeded == true && TimelinePlayed == false)
                {
                    Timeline.Play();
                    TimelinePlayed = true;
                }

                current = item;
                IsActive = state;
                spr.sprite = (IsActive ? item.active : item.inactive); // (Ternaire) si IsActive = true : vert else :rouge
                if (IsActive)
                {
                    GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                    Destroy(fx, 2f);
                }
                if (tag != null && other.IsActive == this.IsActive && IsActive)
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
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    RefreshState(!IsActive, collision.tag);
    //}
}
