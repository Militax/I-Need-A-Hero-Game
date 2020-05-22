using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterial : MonoBehaviour
{
    public Material Shader;
    public GameObject ParticleSystem;
    float Cooldown = 10;
    bool CanParticle = true;
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
        if ((other.CompareTag("Sword") && CanParticle == true) || (other.CompareTag("WindWave")) && CanParticle == true)
        {
            Debug.Log("ParticuleArbre");
            GameObject fx = Instantiate(ParticleSystem, this.transform.position, Quaternion.Euler(90, 0, 0));
            StartCoroutine(SafeCooldown());
            Destroy(fx, 10f);
        }
    }

    IEnumerator SafeCooldown()
    {
        CanParticle = false;
        yield return new WaitForSeconds(Cooldown);
        CanParticle = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
