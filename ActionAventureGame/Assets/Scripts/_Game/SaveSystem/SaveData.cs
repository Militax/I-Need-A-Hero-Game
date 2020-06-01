using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RawData
{
    private static RawData _current;
    public static RawData current
    {
        get
        {
            if (_current == null)
                _current = new RawData();

            return _current;
        }

        set
        {
            if (value != null)
                _current = value;
        }

    }

    // Raw data
    public GameManagerData ManagerData;
}

[System.Serializable]
public class SceneData
{
    private static SceneData _current;
    public static SceneData current
    {
        get
        {
            if (_current == null)
                _current = new SceneData();

            return _current;
        }

        set
        {
            if (value != null)
                _current = value;
        }

    }

    // Scene data
    public PlayerData PlayerData;
    public ActivationDevicesData[] InteractablesData;
    public MovableObjectData[] MovableData;
}