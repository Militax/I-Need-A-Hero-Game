using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SwitchEnnemies : ActivationDevice
{
	//9A13
    public List<GameObject> ennemies = new List<GameObject>();
    private GameObject instance;
    public bool deSpawnOnLeave = true;
    public GameObject eventObject;

    public GameObject FirePit;
    private PlayableDirector Timeline;
    public bool TimelineNeeded;
    Animator animator;

    public Vector3 eventPosition;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(!IsActive, collision.tag);
    }


    protected override void RefreshState(bool state, string tag = null)
    {

        foreach (Combination item in combinations)
        {

            if (item.colliderTag == tag)
            {
                if (ennemies.Count == 0)
                {
                    current = item;
                    IsActive = state;
					//la
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
                    //fin
                    //spr.sprite = (IsActive ? item.active : item.inactive);
                    if (IsActive)
                    {
                        animator.SetTrigger("ToActive");
                    }
                    else if (!IsActive)
                    {
                        animator.SetTrigger("ToInactive");
                    }
                    base.RefreshState(state, tag);
                    break;
                }
            }

        }
    }
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (TimelineNeeded == true)
        {
            Timeline = FirePit.GetComponent<PlayableDirector>();
        }

    }
    private void Update()
    {
        ennemies.RemoveAll(item => item == null);
        if (ennemies.Count == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        animator = gameObject.GetComponent<Animator>();
    }
	//pour affichage
	private void OnDrawGizmos()
    {
        if (eventObject)
        {

            Gizmos.color = new Color(1, 1, 0, .2f);
            Gizmos.DrawCube(transform.position + eventPosition, new Vector3(1, 1, 0));
            Gizmos.DrawLine(transform.position, transform.position + eventPosition);
        }

    }
}
