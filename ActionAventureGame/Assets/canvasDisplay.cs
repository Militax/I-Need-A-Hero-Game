using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasDisplay : MonoBehaviour
{
    public GameObject content;
    public List<int> disabled = new List<int>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoad;
    }

    private void OnLoad(Scene scene, LoadSceneMode mode)
    {
        content.SetActive(!disabled.Contains(scene.buildIndex));
    }
}
