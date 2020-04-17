using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;




public class StayDead : MonoBehaviour
{
    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    int numberofDeath = 0;
    // Start is called before the first frame update
    void Start()
    {
        numberofDeath = GameManager.Instance.DeathCounter;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.DeathCounter == numberofDeath)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = state1;
        }
        else if (GameManager.Instance.DeathCounter == numberofDeath+1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = state2;
        }
        else if (GameManager.Instance.DeathCounter == numberofDeath+2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = state3;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //private void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}

}
