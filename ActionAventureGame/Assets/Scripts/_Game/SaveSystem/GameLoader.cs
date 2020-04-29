using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;
using System.Linq;
public class GameLoader : MonoBehaviour
{
    public string saveFile;
    private void Awake() => OnLoad(Application.persistentDataPath + "/saves/" + saveFile + ".save");

    #region "Activation Device"
    private void LoadActivationDevice(string path)
    {
        ActivationDevice[] Devices = GameObject.FindObjectsOfType<ActivationDevice>();

        SaveData.current = (SaveData)SerializationManager.Load(path);
        if (SaveData.current == null || SaveData.current.InteractablesData == null)
            return;
        Debug.Log("found: " + Devices.Length + " saved: " + SaveData.current.InteractablesData.Length);
        for (int i = 0; i < SaveData.current.InteractablesData.Length; i++)
        {
            ActivationDevicesData.Combination combination = SaveData.current.InteractablesData[i].current;
            
            Devices[i].IsActive = SaveData.current.InteractablesData[i].IsActive;
            Devices[i].HasBeenActivated = SaveData.current.InteractablesData[i].HasBeenPressed;
            Devices[i].current.colliderTag = combination.colliderTag;
            Devices[i].LoadFromSave();
        }

        
    }
    private void SaveActivationDevice()
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
        
        
    }
    

    #endregion

    #region "Movable Objects"
    private void LoadMovableObjects(string path)
    {
        MovableObject[] Movables = GameObject.FindObjectsOfType<MovableObject>();

        SaveData.current = (SaveData)SerializationManager.Load(path);
        if (SaveData.current == null || SaveData.current.MovableData == null)
            return;
        Movables = Movables.OrderBy(t => t.SaveID).ToArray();
        for (int i = 0; i < SaveData.current.MovableData.Length; i++)
        {
            MovableObjectData Data = SaveData.current.MovableData[i];

            Movables[i].transform.position = SaveData.current.MovableData[i].position;
            Movables[i].transform.rotation = SaveData.current.MovableData[i].rotation;
            Movables[i].SaveID = SaveData.current.MovableData[i].ID;
            
        }

    }
    private void SaveMovableObjects()
    {
        MovableObject[] Movables = GameObject.FindObjectsOfType<MovableObject>();
        MovableObjectData[] MovablesData = new MovableObjectData[Movables.Length];
        for (int i = 0; i < Movables.Length; i++)
        {
            if (Movables[i].SaveID > -1)
            {
                Movables[i].SaveID = i;
            }
            
            MovablesData[i] = new MovableObjectData() 
            { ID = i, position = Movables[i].transform.position, rotation = Movables[i].transform.rotation };
            
        }
        SaveData.current.MovableData = MovablesData;
        
    }

    #endregion
    void OnLoad(string path)
    {
        LoadActivationDevice(path);
        LoadMovableObjects(path);
    }

    public void SaveGame()
    {
        SaveActivationDevice();
        SaveMovableObjects();
        SerializationManager.Save(saveFile, SaveData.current);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SaveGame();
    }
}
