using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SaveSystem;
using System.Linq;
using GameManagement;

public class PlayGame : MonoBehaviour
{
    public Text MyText;
    public Transform saveGrid;
    public GameObject buttonPrefab;

    private void Start()
    {
        string[] saves = SaveDictionary.GetAllSaves();

        if (GameManager.Instance)
            GameManager.Instance.currentSave = null;
        if (saves == null)
            return;
        foreach (string item in saves)
            AddSaveButton(item);
    }

    private void AddSaveButton(string name)
    {
        GameObject instance = Instantiate(buttonPrefab, saveGrid);

        instance.GetComponentInChildren<Text>().text = SaveDictionary.GetPrefix(name);
        instance.GetComponentInChildren<Button>().onClick.AddListener(
            delegate
            {
                LoadSave(name);
            });
    }

    public void LoadSave(string name)
    {
        string save = SaveDictionary.GetPrefix(name);
        string last = SaveDictionary.GetLastScene(name);

        Debug.Log(string.Format("Loading from Menu to {0}", save));
        GameManagement.GameManager.Instance.currentSave = save;
        if (last == null)
            NextLevelButton(1);
        else
            NextLevelButton(last);
    }

    public void NewSave()
    {
        if (string.IsNullOrWhiteSpace(MyText.text) || string.IsNullOrEmpty(MyText.text) || !MyText.text.All(x => char.IsLetterOrDigit(x)))
        {
            Debug.LogError("Enter A Valid Name");
            return;
        }
        GameManagement.GameManager.Instance.currentSave = MyText.text;
        NextLevelButton(1);
    }

    public void NextLevelButton(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void NextLevelButton(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
