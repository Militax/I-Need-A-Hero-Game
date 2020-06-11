using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MortEnnemis : MonoBehaviour
{

    public List<GameObject> ennemies = new List<GameObject>();
    public PlayableDirector Timeline;
    private bool timelinePlayed;


    // Start is called before the first frame update
    void Start()
    {
        timelinePlayed = false;
        Timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        ennemies.RemoveAll(item => item == null);
        if (ennemies.Count == 0 && timelinePlayed == false)
        {
            Debug.Log("MORTS IDIOTS");
            Timeline.Play();
            Timeline.stopped += OnPlayableDirectorStopped;
        }
    }

    public void OnPlayableDirectorStopped(PlayableDirector Timeline)
    {
        timelinePlayed = true;
    }
}
