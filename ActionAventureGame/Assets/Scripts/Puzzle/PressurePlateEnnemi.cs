using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlateEnnemi : ActivationDevice

{
	public List<GameObject> ennemies = new List<GameObject>();

    public bool stayActive = false;
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;

    public Vector3 eventPosition;

    public bool WasActivated;
    public GameObject ParticleSystem;

    [Header("Audio")]
    public AudioClip pressurePlateAudio;




    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }

    private void Update()
    {
        ennemies.RemoveAll(item => item == null);
        if (ennemies.Count == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
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

                spr.sprite = (IsActive ? item.active : item.inactive);
                if (stayActive)
                {
                    if (IsActive && !WasActivated)
                    {
                        WasActivated = true;
                        SoundManager.instance.PlaySfx(pressurePlateAudio, 1, 1);
                        GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                        Destroy(fx, 2f);
                    }
                }
                else if (!stayActive)
                {
                    if (IsActive)
                    {
                        SoundManager.instance.PlaySfx(pressurePlateAudio, 1, 1);
                        GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
                        Destroy(fx, 2f);
                    }
                }

                base.RefreshState(state, tag);

                break;
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
}
