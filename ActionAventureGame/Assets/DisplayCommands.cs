using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCommands : MonoBehaviour
{
    
    public void displayCommands(GameObject commands)
    {
        if (commands.activeSelf)
        {
            commands.SetActive(false);
        }
        else if (!commands.activeSelf)
        {
            commands.SetActive(true);
        }
        
    }
   
}
