using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleSwiches : ActivationDevice
{
    
    public doubleSwiches other;
   
    //public GameObject active;
    //public GameObject inactive;
    // Start is called before the first frame update
    private void Start()
    {
        
        IsActive = (spr.color == Color.green);//ternaire  defini actiuf/ inactif selon la couleur du prefab
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (inactive.activeSelf)
    //    {
    //        IsActive = false;
    //    }
    //}
    

    protected override void RefreshState(bool state, string tag = null)
    {
        if (tag == "Sword" || tag == null)
        {
            IsActive = state;
            spr.color = (IsActive ? Color.green : Color.red); // (Ternaire) si IsActive = true : vert else :rouge
            if(tag != null)
                other.RefreshState(!IsActive);
            base.RefreshState(state, tag);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshState(!IsActive, collision.tag);

        //if (collision.tag == "Sword" && IsActive == false)
        //{
        //    active.SetActive(true);
        //    inactive.SetActive(false);
        //    IsActive = true;
        //}
        //else if (collision.tag == "Sword" && IsActive == true)
        //{
        //    inactive.SetActive(true);
        //    active.SetActive(false);
        //    IsActive = false;
        //}
    }
}
