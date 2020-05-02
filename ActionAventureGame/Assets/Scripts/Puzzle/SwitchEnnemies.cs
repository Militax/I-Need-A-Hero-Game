using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEnnemies : ActivationDevice
{

    public List<GameObject> ennemies = new List<GameObject>();
    private GameObject instance;
    public bool deSpawnOnLeave = true;
    public GameObject eventObject;

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
                    if (IsActive && eventObject && instance == null)
                    {
                        instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
                        iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
                    }

                    else if (!IsActive && instance && deSpawnOnLeave)
                        Destroy(instance);

                    spr.sprite = (IsActive ? item.active : item.inactive);
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
}
