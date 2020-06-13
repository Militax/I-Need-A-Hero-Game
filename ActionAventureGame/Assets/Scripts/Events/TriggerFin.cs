using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Boss;
using Player;
using GameManagement;
using Cinemachine;

public class TriggerFin : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Boss;
    public GameObject Player;

    public PlayableAsset playableAsset;

    // Start is called before the first frame update
    void Start()
    {
        
        Timeline = GetComponent<PlayableDirector>();

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

    // Update is called once per frame
    void Update()
    {

        if (Boss.GetComponent<BossHealth>().CurrentBossLife <= 0)
        {
            Camera.main.GetComponent<BossCamera>().enabled = false;
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Timeline.Play();

            if (SoundManager.instance.musicSource.isPlaying)
            {
                SoundManager.instance.musicSource.Stop();
            }
            SoundManager.instance.sfxSource.Stop();

            GameManager.Instance.playerCanMove = false;
            //GameManager.Instance.player.enabled = false;
            //GameManager.Instance.player.rb.velocity = Vector2.zero;
        }



    }
}
