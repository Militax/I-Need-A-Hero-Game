using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ennemy;
using Player;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject ennemi;
    public GameObject linkedInput;
    public PlayerMovement player;
    bool activateonce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (linkedInput.activeSelf)
        {
            activate();
        }
        else if (!linkedInput.activeSelf)
        {
            activateonce = true;
        }
    }
    void activate()
    {
        if (activateonce == true)
        {
            GameObject Gingerbread =Instantiate(ennemi, gameObject.transform.position, Quaternion.identity);
            Gingerbread.GetComponent<GingerbreadMovement>().player = player;
            Gingerbread.GetComponent<GingerbreadAttack>().player = player;
            activateonce = false;
        }

    }
}
