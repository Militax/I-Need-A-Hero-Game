using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;
using GameManagement;
public class IntroForest : MonoBehaviour
{
    public PlayableDirector Timeline;
    public PlayableAsset playableAsset;


    // Start is called before the first frame update
    void Start()
    {
        Timeline = GetComponent<PlayableDirector>();

        var outputs = playableAsset.outputs;
        foreach(var itm in outputs)
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







        if (!GameManager.Instance.IntroHasBeenPlayed)
        {

            Timeline.Play();

            GameManager.Instance.playerCanMove = false;
            GameManager.Instance.powerState = 0;
            //(FindObjectOfType<PlayerMovement>()).enabled = false;
            GameManager.Instance.player.rb.velocity = Vector2.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
