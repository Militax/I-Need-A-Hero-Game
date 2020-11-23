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
    public Slider slider;
    public GameObject laodingScreen;
    private AsyncOperation scene;
   

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

    private void Update()
    {
        if(slider.gameObject.activeSelf)
        slider.value = Mathf.Clamp01(scene.progress / 0.9f);
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
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.musicSource.loop = false;


        StartCoroutine(NextLevelCoroutine(index));
    }

    public void NextLevelButton(string levelName)
    {
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.musicSource.loop = false;

        StartCoroutine(NextLevelCoroutine(levelName));
    }

    IEnumerator NextLevelCoroutine(int index)
    {

        laodingScreen.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            laodingScreen.GetComponent<Image>().color = new Color(0, 0, 0, i/100);
            
            yield return new WaitForSeconds(0.01f);
        }
        slider.gameObject.SetActive( true);
        scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;
        yield return new WaitUntil(() => scene.progress >= 0.89f);
        scene.allowSceneActivation =true;
    }
    IEnumerator NextLevelCoroutine(string levelName)
    {
        laodingScreen.SetActive(true); 
        for (int i = 0; i < 100; i++)
        {
            laodingScreen.GetComponent<Image>().color = new Color(0, 0, 0, i/100);
            yield return new WaitForSeconds(0.01f);
        }
        slider.gameObject.SetActive(true);


        scene = SceneManager.LoadSceneAsync(levelName);
        scene.allowSceneActivation = false;
        yield return new WaitUntil(() =>scene.progress >= 0.89f);
        scene.allowSceneActivation = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
