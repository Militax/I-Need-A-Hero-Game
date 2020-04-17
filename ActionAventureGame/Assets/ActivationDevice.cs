using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class ActivationDevice : MonoBehaviour
{
    [System.Serializable]
    public class Combination
    {
        public string colliderTag;
        public Sprite active;
        public Sprite inactive;
    }
    [HideInInspector] public Combination current;
    public Combination[] combinations;

    public bool HasBeenActivated = false;
    public bool IsActive;
    protected SpriteRenderer spr;

    protected virtual void RefreshState(bool state, string tag = null)  // demande un state et optionnelement un string
    {
        HasBeenActivated = true;
        
    }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void LoadFromSave()
    {

        Combination my = combinations.Where(c => c.colliderTag == current.colliderTag).FirstOrDefault();  //foreach en une ligne (pour flex)
        spr = GetComponent<SpriteRenderer>();
        if (my != null)
            spr.sprite = (IsActive ? my.active : my.inactive);
    }
}
