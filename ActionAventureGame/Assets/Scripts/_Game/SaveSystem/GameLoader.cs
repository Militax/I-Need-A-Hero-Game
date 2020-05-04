using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
using GameManagement;
using Puzzle;
using System.Linq;
using Management;
using Player;
public class GameLoader : MonoBehaviour
{
    public string saveName;
    public PlayerMovement player;

    private void Awake()
    {
        //MakeSingleton(false);
        LoadGame(saveName);
    }
    #region "Activation Device"
    private void LoadActivationDevice(ActivationDevicesData[] data)
    {
        ActivationDevice[] Devices = GameObject.FindObjectsOfType<ActivationDevice>();

        if (data == null)
            return;
        for (int i = 0; i < data.Length; i++)
        {
            ActivationDevicesData.Combination combination = data[i].current;

            Devices[i].IsActive = data[i].IsActive;
            Devices[i].HasBeenActivated = data[i].HasBeenPressed;
            Devices[i].current.colliderTag = combination.colliderTag;
            Devices[i].LoadFromSave();
        }
    }

    private void SaveActivationDevice(SaveData data)
    {
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
        data.InteractablesData = devicesDatas;
    }
    #endregion

    #region "Movable Objects"
    private void LoadMovableObjects(MovableObjectData[] data)
    {
        MovableObject[] Movables = GameObject.FindObjectsOfType<MovableObject>();

        if (data == null)
            return;
        Movables = Movables.OrderBy(t => t.SaveID).ToArray();
        for (int i = 0; i < data.Length; i++)
        {
            Movables[i].transform.position = data[i].position;
            Movables[i].transform.rotation = data[i].rotation;
            Movables[i].SaveID = data[i].ID;
        }
    }

    private void SaveMovableObjects(SaveData data)
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
        data.MovableData = MovablesData;
    }
    #endregion

    #region GameManager
    private void LoadGameManager(GameManagerData data)
    {
        if (data == null )
            return;
        if (GameManager.Instance == null)
            Debug.LogError("Gamemanager is null");
        GameManager.Instance.RespawnPoint = data.RespawnPoint;
        GameManager.Instance.SetHealth(data.PlayerHP, data.PlayerMaxHP);
        GameManager.Instance.playerHealth = data.PlayerHP;
        GameManager.Instance.playerHealthMax = data.PlayerMaxHP;
        GameManager.Instance.CoinOwned = data.Coins;
        GameManager.Instance.maxCoin = data.MaxCoins;
        GameManager.Instance.powerState = data.PowerState;
        GameManager.Instance.DeathCounter = data.DeathCounter;
        GameManager.Instance.swordDamage = data.SwordDamage;
        GameManager.Instance.bottesState = data.BottesState;
    }

    private void SaveGameManager(SaveData data)
    {

        GameManagerData managerData;
        managerData = new GameManagerData()
        {
            RespawnPoint = GameManager.Instance.RespawnPoint,
            PlayerHP = GameManager.Instance.playerHealth,
            PlayerMaxHP = GameManager.Instance.playerHealthMax,
            Coins = GameManager.Instance.CoinOwned,
            MaxCoins = GameManager.Instance.maxCoin,
            PowerState = GameManager.Instance.powerState,
            DeathCounter = GameManager.Instance.DeathCounter,
            SwordDamage = GameManager.Instance.swordDamage,
            BottesState = GameManager.Instance.bottesState
        };
        data.ManagerData = managerData;
    }
    #endregion

    public void LoadGame(string save)
    {
        SaveData.current = (SaveData)SaveDictionary.Load(save);
        if (SaveData.current == null)
        {
            Debug.Log(string.Format("No save named '{0}' has been found.", save));
            return;
        }
        LoadActivationDevice(SaveData.current.InteractablesData);
        LoadMovableObjects(SaveData.current.MovableData);
        //LoadGameManager(SaveData.current.ManagerData);
        Debug.Log(string.Format("Game '{0}' successfully loaded !", save));
    }

    public void SaveGame(string save)
    {
        string savedFile;

        SaveActivationDevice(SaveData.current);
        SaveMovableObjects(SaveData.current);
        //SaveGameManager(SaveData.current);
        savedFile = SaveDictionary.Save(SaveData.current, save);
        Debug.Log(string.Format("Game '{0}' has been saved in file '{1}'.", save, savedFile));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SaveGame(saveName);
    }
}
