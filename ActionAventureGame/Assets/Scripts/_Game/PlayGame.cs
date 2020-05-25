using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SaveSystem;

public class PlayGame : MonoBehaviour
{
    public Text MyText;
    public Transform saveGrid;
    public GameObject buttonPrefab;

    private void Start()
    {
        string[] saves = SaveDictionary.GetAllSaves();

        if (saves == null)
            return;
        foreach (string item in saves)
            AddSaveButton(item);
    }

    private void AddSaveButton(string name)
    {
        GameObject instance = Instantiate(buttonPrefab, saveGrid);

        instance.GetComponentInChildren<Text>().text = name;
        instance.GetComponentInChildren<Button>().onClick.AddListener(
            delegate 
            { 
                LoadSave(name); 
            });
    }

    public void LoadSave(string name)
    {
        string save = SaveDictionary.GetPrefix(name);

        if (save != null)
        {
            //TODO: Instance GameManager in MainMenu scene
            // GameManagement.GameManager.Instance.currentSave = save;
            SaveDictionary.Load(save);
        }
        NextLevelButton(0);
    }

    public void NewSave()
    {
        SaveDictionary.Load(MyText.text);
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
