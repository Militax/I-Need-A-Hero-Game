using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using UnityEngine.Playables;

public class GetWindPower : MonoBehaviour
{
    public int stateWanted;

    public GameObject PlayableDirector;
    private PlayableDirector Timeline;
    // Start is called before the first frame update
    void Start()
    {
        Timeline = PlayableDirector.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        Timeline.stopped += OnplayableDirectorStopped;
    }
    void OnplayableDirectorStopped(PlayableDirector playable)
    {
        GameManager.Instance.powerState = stateWanted;
    }
}
