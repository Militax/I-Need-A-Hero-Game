﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;


public class TriggerBoss : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Boss;

    private bool TimelinePlayed;
    private int powerlvl;

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
        TimelinePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        powerlvl = GameManager.Instance.powerState;

        if (TimelinePlayed == false)
        {
            GameManager.Instance.playerCanMove = false;
            GameManager.Instance.powerState = 0;
            Timeline.stopped += OnPlayableDirectorStopped;
        }
        
    }

    void OnPlayableDirectorStopped(PlayableDirector IntroBoss)
    {
        Boss.SetActive(true);
        TimelinePlayed = true;
        GameManager.Instance.playerCanMove = true;
        GameManager.Instance.powerState = powerlvl;
    }
}
