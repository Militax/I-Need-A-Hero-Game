using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class GingerbreadSpawnerBoss : MonoBehaviour
{
    public GameObject Gingerbread;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private bool _canInstaciate = true;
    [SerializeField]
    private bool _isWaiting = false;

    private void Start()
    {
        Debug.Log("Start "+name);
        _canInstaciate = true;
        _isWaiting = false;
    }
    void FixedUpdate()
    {
        
        if (this.transform.childCount <= 0)
        {
            Debug.Log("Can "+name+" instanciate Ggb ? " + _canInstaciate);
            if (_canInstaciate)
            {
                InstanciateNewGingerbread();

            }
            else if (!_isWaiting)
            {
                StartCoroutine("Cooldown");
            }

        }
    }
    void InstanciateNewGingerbread()
    {
        Debug.Log("I will instanciate the gingerbread !");
        GameObject myGingerBread = Instantiate(Gingerbread);
        myGingerBread.transform.SetParent(this.transform);
        myGingerBread.transform.localPosition = Vector3.zero;
        _canInstaciate = false;
    }
    IEnumerator Cooldown()
    {
        Debug.Log("I'll Wait for " + _cooldown + " sec");
        _isWaiting = true;
        yield return new WaitForSeconds(_cooldown);
        _canInstaciate = true;
        _isWaiting = false;
        Debug.Log("End Waiting for respawn.");

    }
}
