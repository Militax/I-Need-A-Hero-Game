using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ennemy;
using Player;

public class SpawnEnemy : MonoBehaviour
{
   public GameObject[] ennemi;
    public ActivationDevice linkedInput;
    public PlayerMovement player;
    bool activateonce = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (linkedInput == null)
        {
            return;
        }

        if (linkedInput.IsActive)
        {
            activate();
        }
    }
    void activate()
    {
        if (activateonce == true)
        {
            foreach (GameObject item in ennemi)
            {
                item.SetActive(true);
            }
            activateonce = false;
        }

    }
}
