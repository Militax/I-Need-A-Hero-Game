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
    public PlayableDirector TimelineMortEnnemis;
    public bool TimelineMortEnnemisNeeded;
    private bool TimelinePlayed;

    Animator animator;
    public GameObject ParticleSystem;

    public Vector3 eventPosition;


    [Header("Audio")]
    public AudioClip switchOn;
    public AudioClip switchOff;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(!IsActive, collision.tag);
    }


    public override void RefreshState(bool state, string tag = null)
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
                        SoundManager.instance.PlaySfx(switchOn, 1, 1);

                        if (ParticleSystem != null)
                        {
                            GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                            Destroy(fx, 2f);
                        }
                    }
                    else if (!IsActive)
                    {
                        animator.SetTrigger("ToInactive");
                        SoundManager.instance.PlaySfx(switchOff, 1, 1);
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

        TimelinePlayed = false;

    }
    private void Update()
    {
        ennemies.RemoveAll(item => item == null);
        if (ennemies.Count == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            if (TimelineMortEnnemisNeeded == true && TimelinePlayed == false)
            {
                TimelineMortEnnemis.Play();
                TimelineMortEnnemis.stopped += OnPlayableDirectorStopped;
            }
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

    void OnPlayableDirectorStopped(PlayableDirector ZoneSud)
    {
        TimelinePlayed = true;
    }
}
