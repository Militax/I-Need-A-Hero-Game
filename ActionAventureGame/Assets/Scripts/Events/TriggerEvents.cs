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
    private int powerlvl;
    
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
            powerlvl = GameManager.Instance.powerState;

            if (TimelinePlayed == false)
            {

                Timeline.Play();

                GameManager.Instance.playerCanMove = false;
                GameManager.Instance.powerState = 0;
                //(FindObjectOfType<PlayerMovement>()).enabled = false;
                GameManager.Instance.player.rb.velocity = Vector2.zero;

                Timeline.stopped += OnPlayableDirectorStopped;
            }
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        TimelinePlayed = true;
        GameManager.Instance.playerCanMove = true;
        GameManager.Instance.powerState = powerlvl;
        //(FindObjectOfType<PlayerMovement>()).enabled = true;
        GameManager.Instance.player.rb.velocity = GameManager.Instance.player.movement.normalized * (GameManager.Instance.player.moveSpeed * 50) * Time.deltaTime;
    }
}
