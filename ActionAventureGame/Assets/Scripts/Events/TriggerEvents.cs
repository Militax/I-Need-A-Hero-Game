using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;
using GameManagement;

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
        if (collision.tag == "Player")
        {
            if (TimelinePlayed == false)
            {

                Timeline.Play();

                GameManager.Instance.playerCanMove = false;
                //(FindObjectOfType<PlayerMovement>()).enabled = false;
                //Player.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;

                Timeline.stopped += OnPlayableDirectorStopped;
            }
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
        GameManager.Instance.playerCanMove = true;
        //(FindObjectOfType<PlayerMovement>()).enabled = true;
        //GameManager.Instance.player.rb.velocity = GameManager.Instance.player.movement.normalized * (GameManager.Instance.player.moveSpeed * 50) * Time.deltaTime;
    }
}
