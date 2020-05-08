using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Boss;


public class TriggerBoss : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector MontéeEau)
    {
        Boss.SetActive(true);
    }
}
