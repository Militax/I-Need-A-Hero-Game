using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class GingerbreadSpawnerBoss : MonoBehaviour
{
    public GameObject Gingerbread;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0)
        {
            GameObject myGingerBread = Instantiate(Gingerbread);
            myGingerBread.transform.SetParent(transform);
            myGingerBread.transform.localPosition = Vector3.zero;
        }
    }
}
