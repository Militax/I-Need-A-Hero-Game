using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Ennemy;

public class destroyBox : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject ennemi;
    public GameObject spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Box")
        {
            Destroy(other);
            GameObject Gingerbread = Instantiate(ennemi, spawnpoint.transform.position, Quaternion.identity);
            Gingerbread.GetComponent<GingerbreadMovement>().player = player;
            Gingerbread.GetComponent<GingerbreadAttack>().player = player;
        }
    }
}
