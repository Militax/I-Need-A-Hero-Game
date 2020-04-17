using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(deactivate());
    }

    IEnumerator deactivate()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
