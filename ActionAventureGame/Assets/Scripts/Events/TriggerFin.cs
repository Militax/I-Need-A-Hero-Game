using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Boss;
using Player;
using GameManagement;

public class TriggerFin : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Boss;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Boss.GetComponent<BossHealth>().CurrentBossLife <= 0)
        {
            Timeline.Play();
            GameManager.Instance.playerCanMove = false;
            //GameManager.Instance.player.enabled = false;
            //GameManager.Instance.player.rb.velocity = Vector2.zero;
        }



    }
}
