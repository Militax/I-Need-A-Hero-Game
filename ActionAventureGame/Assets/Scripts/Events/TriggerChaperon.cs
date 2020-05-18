using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;

public class TriggerChaperon : MonoBehaviour
{
    private PlayableDirector Timeline;
    private PlayableDirector Gueulante;

    private bool TimelinePlayed;

    public GameObject TimelineDirector;
    public GameObject GueulanteDirector;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = TimelineDirector.GetComponent<PlayableDirector>();
        Gueulante = GueulanteDirector.GetComponent<PlayableDirector>();
     
        
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Gueulante.Stop();
            TimelinePlayed = false;
            Timeline.Play();
            Timeline.stopped += OnPlayableDirectorStopped;
        }
       
    }

    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            
            if (TimelinePlayed == false)
            {
                Gueulante.Play();
                Timeline.stopped += OnGueulanteStopped;
            }

            Timeline.Stop();
        }
        
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
    }

    void OnGueulanteStopped (PlayableDirector Gueulante)
    {
        Timeline.Stop();
        Debug.Log("stopped");
    }
}
