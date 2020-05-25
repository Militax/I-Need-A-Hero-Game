using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class SaveButton : MonoBehaviour
{
    public void SaveBtn()
    {
        if (GameManager.Instance.currentSave != null)
        {
            GameLoader.Instance.SaveGame(GameManager.Instance.currentSave);
        }
        
    }
}
