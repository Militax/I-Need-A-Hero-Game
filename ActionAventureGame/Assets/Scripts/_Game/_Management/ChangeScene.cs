using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameManagement;

public class ChangeScene : MonoBehaviour
{
    public string NextScene;
    public GameLoader tamere;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (NextScene == "Forest")
            {
                GameManager.Instance.isComingFromDonjon = true;
            }
            else
            {
                GameManager.Instance.isComingFromDonjon = false;
                tamere.SaveGame(tamere.saveName);
            }

            SceneManager.LoadScene(NextScene);
        }
    }
}
