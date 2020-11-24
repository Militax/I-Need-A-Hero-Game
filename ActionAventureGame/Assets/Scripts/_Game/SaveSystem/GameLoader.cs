using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SaveSystem;
using GameManagement;
using Puzzle;
using System.Linq;
using Management;
using Player;
using System.IO;

public class GameLoader : Singleton<GameLoader>
{
    #region ForestArray

    public MovableObject[] boxArray;
    public ActivationDevice[] switchArray;

    #endregion


    private void Start()
    {
        MakeSingleton(false);
        if (GameManager.Instance)
            print("Current scene: " + GameManager.Instance.currentSave);
        if (GameManager.Instance == null || GameManager.Instance.currentSave == null || string.IsNullOrEmpty(GameManager.Instance.currentSave))
        {
            Debug.LogError("An error occured while loading save. Scene Event: " + SceneManager.GetActiveScene().name);
            return;
        }
        LoadGame(GameManager.Instance.currentSave);
    }

    #region "Activation Device"
    private void LoadActivationDevice(ActivationDevicesData[] data)
    {
        ActivationDevice[] Devices = switchArray;

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

    private void SaveActivationDevice(SceneData data)
    {
        ActivationDevice[] Devices = switchArray;
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
        MovableObject[] Movables = boxArray;

        if (data == null)
            return;
        Movables = Movables.OrderBy(t => t.SaveID).ToArray();
        for (int i = 0; i < data.Length; i++)
        {
            Movables[i].transform.position = data[i].position;
            Movables[i].transform.rotation = data[i].rotation;
            Movables[i].SaveID = data[i].ID;
            Movables[i].powerStateRequest = data[i].powerStateRequest;

        }
    }

    private void SaveMovableObjects(SceneData data)
    {
        MovableObject[] Movables = boxArray;
        MovableObjectData[] MovablesData = new MovableObjectData[Movables.Length];
        for (int i = 0; i < Movables.Length; i++)
        {
            if (Movables[i].SaveID > -1)
            {
                Movables[i].SaveID = i;
            }

            MovablesData[i] = new MovableObjectData()
            { ID = i, 
                position = Movables[i].transform.position,
                rotation = Movables[i].transform.rotation,
                powerStateRequest = Movables[i].powerStateRequest
            };

        }
        data.MovableData = MovablesData;
    }
    #endregion

    #region GameManager
    private void LoadGameManager(GameManagerData data)
    {
        if (data == null)
            return;
        if (GameManager.Instance == null)
            Debug.LogError("Gamemanager is null");

        GameManager.Instance.playerCanMove = data.CanMove;
        Debug.Log(GameManager.Instance.playerCanMove);
        GameManager.Instance.RespawnPoint = data.RespawnPoint;
        GameManager.Instance.playerHealth = data.PlayerHP;
        GameManager.Instance.playerHealthMax = data.PlayerMaxHP;
        GameManager.Instance.CoinOwned = data.Coins;
        GameManager.Instance.maxCoin = data.MaxCoins;
        GameManager.Instance.powerState = data.PowerState;
        GameManager.Instance.DeathCounter = data.DeathCounter;
        GameManager.Instance.swordDamage = data.SwordDamage;
        GameManager.Instance.bottesState = data.BottesState;
        GameManager.Instance.isComingFromDonjon = data.isCommingFromDungeon;
        GameManager.Instance.isComingFromForest = data.isCommingFromForest;
        GameManager.Instance.IntroHasBeenPlayed = data.hasBeenPlayed;
    }

    private void SaveGameManager(RawData data)
    {

        GameManagerData managerData;
        managerData = new GameManagerData()
        {
            CanMove = GameManager.Instance.playerCanMove,
            RespawnPoint = GameManager.Instance.RespawnPoint,
            PlayerHP = GameManager.Instance.playerHealth,
            PlayerMaxHP = GameManager.Instance.playerHealthMax,
            Coins = GameManager.Instance.CoinOwned,
            MaxCoins = GameManager.Instance.maxCoin,
            PowerState = GameManager.Instance.powerState,
            DeathCounter = GameManager.Instance.DeathCounter,
            SwordDamage = GameManager.Instance.swordDamage,
            BottesState = GameManager.Instance.bottesState,
            hasBeenPlayed = GameManager.Instance.IntroHasBeenPlayed,
            isCommingFromDungeon = GameManager.Instance.isComingFromDonjon,
            isCommingFromForest = GameManager.Instance.isComingFromForest
        };
        data.ManagerData = managerData;
    }
    #endregion

    #region "Player"
    private void LoadPlayerData(PlayerData data)
    {
        if (data == null)
            return;
        if (GameManager.Instance == null)
            Debug.LogError("Player is null");

        PlayerMovement player = GameManager.Instance.player;
        
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        Debug.LogError(data.position);
        player.transform.position = data.position;
        player.transform.rotation = data.rotation;
    }

    private void SavePlayerData(SceneData data)
    {
        PlayerData playerData;
        playerData = new PlayerData()
        {
            position = GameManager.Instance.player.transform.position,
            rotation = GameManager.Instance.player.transform.rotation
        };
        data.PlayerData = playerData;
    }

    #endregion

    private void LoadRaw(string save)
    {
        RawData.current = (RawData)SaveDictionary.Load(save, SaveDictionary.RawPreffix);

        if (RawData.current == null)
        {
            Debug.Log("data is null");
            return;
        }
            
        print("Loading raw data: " + save);
        LoadGameManager(RawData.current.ManagerData);
    }

    private void LoadScene(string save)
    {
        if (!File.Exists(SaveDictionary.GetFullPath(save, SceneManager.GetActiveScene().name)))
            return;
        SceneData.current = (SceneData)SaveDictionary.Load(save, SceneManager.GetActiveScene().name);

        if (SceneData.current == null)
            return;
        print("Loading scene data: " + save);
        LoadPlayerData(SceneData.current.PlayerData);
        LoadMovableObjects(SceneData.current.MovableData);
        LoadActivationDevice(SceneData.current.InteractablesData);
    }

    public void LoadGame(string save)
    {
        if (GameManager.Instance == null || GameManager.Instance.currentSave == null || string.IsNullOrEmpty(GameManager.Instance.currentSave))
        {
            Debug.Log("An error occured when loading save. Scene Event: " + SceneManager.GetActiveScene().name);
            return;
        }
        LoadRaw(save);
        LoadScene(save);
        Debug.Log(string.Format("Game '{0}' successfully loaded !", save));
    }

    public void SaveGame(string save)
    {
        string savedFile;

        SaveActivationDevice(SceneData.current);
        SaveMovableObjects(SceneData.current);
        SaveGameManager(RawData.current);
        SavePlayerData(SceneData.current);
        savedFile = SaveDictionary.Save(SceneData.current, save, SceneManager.GetActiveScene().name);
        SaveDictionary.Save(RawData.current, save, SaveDictionary.RawPreffix);
        Debug.Log(string.Format("Game '{0}' has been saved in file '{1}'.", save, savedFile));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            SaveGame(GameManager.Instance.currentSave);
    }
}
