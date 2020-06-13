using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;
using GameManagement;
using Ennemy;

public class TriggerEvents : MonoBehaviour
{
    public PlayableDirector Timeline;
    public PlayableAsset playableAsset;
    private bool TimelinePlayed;
    private int powerlvl;
    public bool dependsFromDungeon;
    public bool dependsFromForest;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = GetComponent<PlayableDirector>();
        TimelinePlayed = false;

        var outputs = playableAsset.outputs;
        foreach (var itm in outputs)
        {
            if (itm.streamName == "PlayerLife")
            {
                Timeline.SetGenericBinding(itm.sourceObject, GameManager.Instance.GetComponent<CanvasManagement>().playerHealth);
            }
            if (itm.streamName == "Bourse")
            {
                Timeline.SetGenericBinding(itm.sourceObject, GameManager.Instance.GetComponent<CanvasManagement>().bourse);
            }
            if (itm.streamName == "Score")
            {
                Timeline.SetGenericBinding(itm.sourceObject, GameManager.Instance.GetComponent<CanvasManagement>().score);
            }
            if (itm.streamName == "Input")
            {
                Timeline.SetGenericBinding(itm.sourceObject, GameManager.Instance.GetComponent<CanvasManagement>().Input);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (dependsFromDungeon && GameManager.Instance.isComingFromDonjon)
            {
                gameObject.SetActive(false);
                return;
            }
            if (dependsFromForest && GameManager.Instance.isComingFromForest)
            {
                gameObject.SetActive(false);
                return;
            }
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
