using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class GingerbreadSpawnerBoss : MonoBehaviour
{
    public GameObject Gingerbread;
    [SerializeField]
    private float cooldown;
    private bool canInstaciate=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.childCount <= 0 )
        {
            if (canInstaciate==true)
            {
                GameObject myGingerBread = Instantiate(Gingerbread);
                myGingerBread.transform.SetParent(transform);
                myGingerBread.transform.localPosition = Vector3.zero;
                canInstaciate = false;
                
            }
            else
            {
                
            }

        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds (cooldown);

    }
}
