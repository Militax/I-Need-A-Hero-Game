using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;
using GameManagement;
public class IntroForest : MonoBehaviour
{
    public PlayableDirector Timeline;


    // Start is called before the first frame update
    void Start()
    {
        Timeline = Timeline = GetComponent<PlayableDirector>();

        if (!GameManager.Instance.IntroHasBeenPlayed)
        {

            Timeline.Play();

            GameManager.Instance.playerCanMove = false;
            GameManager.Instance.powerState = 0;
            //(FindObjectOfType<PlayerMovement>()).enabled = false;
            GameManager.Instance.player.rb.velocity = Vector2.zero;

            Timeline.stopped += OnPlayableDirectorStopped;
        }
    }
    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        GameManager.Instance.IntroHasBeenPlayed = true;
        GameManager.Instance.playerCanMove = true;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
