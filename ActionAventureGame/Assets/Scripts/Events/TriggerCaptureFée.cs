using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;

public class TriggerCaptureFée : MonoBehaviour
{
    public PlayableDirector Timeline;
    private bool TimelinePlayed;
    public GameObject Player;
    public GameObject TimelineDirector;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = TimelineDirector.GetComponent<PlayableDirector>();
        TimelinePlayed = false;
    }

    private void OnDestroy()
    {
        //Debug.Log("CA MARCHE");

        if (TimelinePlayed == false)
        {
            //Debug.Log("CA MARCHE POUR DE VRAI");
            Timeline.Play();
            //(FindObjectOfType<PlayerMovement>()).enabled = false;
            //Player.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
            Timeline.stopped += OnPlayableDirectorStopped;
        }

    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
        //(FindObjectOfType<PlayerMovement>()).enabled = true;
        //Player.GetComponent<PlayerMovement>().rb.velocity = Player.GetComponent<PlayerMovement>().movement.normalized * (Player.GetComponent<PlayerMovement>().moveSpeed * 50) * Time.deltaTime;
    }


}
