using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Anim_HitMort : MonoBehaviour
{
    public Animator animator;
    private int ComboCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        { animator.SetTrigger("Hit"); }

        if (Input.GetKey("m"))
        { animator.SetTrigger("Dead"); }

        if (Input.GetKey("p") && ComboCount == 0)
        {
            ComboCount = 1;
            animator.SetTrigger("Attack 1");
        }
        else if (Input.GetKey("p") && ComboCount >= 1)
        {
            ComboCount += 1;

            if (ComboCount == 2)
            { animator.SetTrigger("Attack 2"); }

            if (ComboCount == 3)
            { animator.SetTrigger("Attack 3");
                ComboCount = 0;
            }
        }

    }
}
