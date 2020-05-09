using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;

public class TriggerChaperon : MonoBehaviour
{
    public PlayableDirector Timeline;
    public PlayableDirector Gueulante;

    private bool TimelinePlayed;

    public GameObject Player;
    public GameObject TimelineDirector;
    public GameObject GueulanteDirector;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = TimelineDirector.GetComponent<PlayableDirector>();
        Gueulante = GueulanteDirector.GetComponent<PlayableDirector>();
     
        TimelinePlayed = false;
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
       Gueulante.Stop();
       Timeline.Play();
       Timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnTriggerExit2D(Collider2D Player)
    {
        if (TimelinePlayed == false)
        {
            Timeline.Pause();
            Gueulante.Play();
            Debug.Log("CA MARCHE");
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
    }

}
