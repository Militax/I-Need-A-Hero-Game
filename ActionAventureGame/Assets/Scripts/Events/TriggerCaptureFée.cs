using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;
using GameManagement;

public class TriggerCaptureFée : MonoBehaviour
{
    private PlayableDirector Timeline;
    private bool TimelinePlayed;
    public GameObject TimelineDirector;
    private int powerlvl;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = TimelineDirector.GetComponent<PlayableDirector>();
        TimelinePlayed = false;

        powerlvl = GameManager.Instance.powerState;
    }

    private void OnDestroy()
    {
        

        if (TimelinePlayed == false)
        {
            
            Timeline.Play();
            GameManager.Instance.playerCanMove = false;
            GameManager.Instance.powerState = 0;
            //(FindObjectOfType<PlayerMovement>()).enabled = false;
            //Player.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
            Timeline.stopped += OnPlayableDirectorStopped;
        }

    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
        GameManager.Instance.playerCanMove = true;
        GameManager.Instance.powerState = powerlvl;
        //(FindObjectOfType<PlayerMovement>()).enabled = true;
        //Player.GetComponent<PlayerMovement>().rb.velocity = Player.GetComponent<PlayerMovement>().movement.normalized * (Player.GetComponent<PlayerMovement>().moveSpeed * 50) * Time.deltaTime;
    }


}
