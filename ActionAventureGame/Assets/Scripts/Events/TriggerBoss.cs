using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Cinemachine;


public class TriggerBoss : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Boss;

    private bool TimelinePlayed;
    private int powerlvl;
    public PlayableAsset playableAsset;

    // Start is called before the first frame update
    void Start()
    {
        Timeline.Play();
        Boss.SetActive(false);
        TimelinePlayed = false;
        Camera.main.GetComponent<BossCamera>().enabled = false;
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;

        

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
}

    // Update is called once per frame
    void Update()
    {
        if (TimelinePlayed == false)
        {
            GameManager.Instance.playerCanMove = false;
            Timeline.stopped += OnPlayableDirectorStopped;
        }
        
    }

    void OnPlayableDirectorStopped(PlayableDirector IntroBoss)
    {
        Boss.SetActive(true);
        GameManager.Instance.powerState = 3;
        TimelinePlayed = true;
        GameManager.Instance.playerCanMove = true;
        Camera.main.GetComponent<BossCamera>().enabled = true;
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
    }
}
