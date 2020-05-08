using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;

public class TriggerEvents : MonoBehaviour
{
    public PlayableDirector Timeline;
    private bool TimelinePlayed;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Timeline = GetComponent<PlayableDirector>();
        TimelinePlayed = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yep");

        if (TimelinePlayed == false)
        {
            Debug.Log("doubleyep");
            Timeline.Play();
            (FindObjectOfType<PlayerMovement>()).enabled = false;
            Player.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
            Timeline.stopped += OnPlayableDirectorStopped;          
        }
       
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
        (FindObjectOfType<PlayerMovement>()).enabled = true;
        Player.GetComponent<PlayerMovement>().rb.velocity = Player.GetComponent<PlayerMovement>().movement.normalized * (Player.GetComponent<PlayerMovement>().moveSpeed * 50) * Time.deltaTime;
    }
}
