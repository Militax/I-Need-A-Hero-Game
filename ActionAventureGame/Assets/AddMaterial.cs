using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterial : MonoBehaviour
{
    public Material Shader;
    public GameObject ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        float newfloat = Random.Range(0,2);
        Invoke("Material", newfloat);
    }

    void Material()
    {
        gameObject.GetComponent<SpriteRenderer>().material = Shader;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword") || other.CompareTag("WindWave"))
        {
            Debug.Log("ParticuleArbre");
            GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.identity);
            Destroy(fx, 2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
