using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichsword : MonoBehaviour
{
    #region Variables
    public GameObject stateOne;
    public GameObject stateTwo;

    public bool isReversible;

    public bool canSwitch;
    #endregion

    void Start()
    {
        Initialisation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //On vérifie que c'est bien la vague qui touche l'objet
        if (other.CompareTag("épée") && canSwitch)
        {
            Debug.Log("WTF");
            //Si l'objet est en etat 1, on le passe en etat 2
            if (stateOne.activeSelf)
            {
                #region To State 2
                stateTwo.SetActive(true);
                stateOne.SetActive(false);
                #endregion
            }
            //Si l'objet est en etat 2, on le passe en etat 1
            else if (stateTwo.activeSelf)
            {
                #region To State 1
                stateOne.SetActive(true);
                stateTwo.SetActive(false);
                #endregion
            }


            //Si l'objet n'est pas reversible, on bloque tout
            if (!isReversible)
            {
                canSwitch = false;
            }
        }
    }


    //Sert à initialiser certaines variable et apporte une sécurité à l'activation des phases
    void Initialisation()
    {
        canSwitch = true;

        if (stateOne.activeSelf)
        {
            stateOne.SetActive(true);
            stateTwo.SetActive(false);
        }
        else if (stateTwo.activeSelf)
        {
            stateOne.SetActive(false);
            stateTwo.SetActive(true);
        }
    }


}
