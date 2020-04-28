using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public string saveFile;
    private void Awake() => OnLoad(Application.persistentDataPath + "/saves/" + saveFile + ".save");
        
    void OnLoad(string path)
    {
        ActivationDevice[] Devices = GameObject.FindObjectsOfType<ActivationDevice>();

        SaveData.current = (SaveData)SerializationManager.Load(path);
        if (SaveData.current == null || SaveData.current.InteractablesData == null)
            return;
        for (int i = 0; i < SaveData.current.InteractablesData.Length; i++)
        {
            ActivationDevicesData.Combination combination = SaveData.current.InteractablesData[i].current;

            Devices[i].IsActive = SaveData.current.InteractablesData[i].IsActive;
            Devices[i].HasBeenActivated = SaveData.current.InteractablesData[i].HasBeenPressed;
            Devices[i].current.colliderTag = combination.colliderTag;
            Devices[i].LoadFromSave();
        }

        Debug.Log("LoadedFromSave");
    }

    public void SaveGame()
    {
        SaveData.current = new SaveData();
        ActivationDevice[] Devices = GameObject.FindObjectsOfType<ActivationDevice>();
        ActivationDevicesData[] devicesDatas = new ActivationDevicesData[Devices.Length];
        
        for (int i = 0; i < Devices.Length; i++)
        {
            ActivationDevice.Combination combination = Devices[i].current;

            devicesDatas[i] = new ActivationDevicesData();
            devicesDatas[i].IsActive = Devices[i].IsActive;
            devicesDatas[i].HasBeenPressed = Devices[i].HasBeenActivated;
            devicesDatas[i].current = new ActivationDevicesData.Combination()
            {
                colliderTag = combination.colliderTag
            };
        }

        SaveData.current.InteractablesData = devicesDatas;
        SerializationManager.Save(saveFile, SaveData.current);
        Debug.Log("GameSaved");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame();
    }
}
