using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère l'ouverture de la porte
    /// </summary>
    public class Door : MonoBehaviour
    {
        public ActivationDevice[] linkedInput;
        public GameObject openState;
        public GameObject closeState;
        public bool startState = false;


        void Update()
        {
            bool state = startState;
            if (linkedInput.Length == 0)
                return;
            foreach (ActivationDevice item in linkedInput)
            {
                if (!item.IsActive)
                    state = !startState;
            }
            closeState.SetActive(state);
            openState.SetActive(!state);

        }



    }
}