using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameManagement;
using Player;

public class ChangeScene : MonoBehaviour
{

    public string NextScene;
    public Vector3 exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (NextScene == "Donjon")
            {
                GameManager.Instance.isComingFromDonjon = true;
            }
            if (NextScene == "Forest")
            {
                GameManager.Instance.isComingFromForest = true;
            }

            collision.transform.position = exit + transform.position;
            GameLoader.Instance.SaveGame(GameManager.Instance.currentSave);
            SceneManager.LoadScene(NextScene);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, exit + transform.position);
        Gizmos.DrawCube(exit + transform.position, new Vector3(.1f, .1f));
    }
}
