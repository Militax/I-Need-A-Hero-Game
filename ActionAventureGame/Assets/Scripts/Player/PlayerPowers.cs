using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Power;
using GameManagement;


namespace Player
{

    /// <summary>
    /// Matis Duperray
    /// 
    /// Script qui attribue une direction et invoque le pouvoir du vent
    /// </summary>
    public class PlayerPowers : MonoBehaviour
    {
        #region Variables
        public GameObject WindPowerPrefab;
        public GameObject FrozenPowerPrefab;
        public GameObject PowerPowerPrefab;
        #region Invocation Points
        public Transform topPoint;
        public Transform downPoint;
        public Transform leftPoint;
        public Transform rightPoint;
        public Transform topLeftPoint;
        public Transform topRightPoint;
        public Transform downLeftPoint;
        public Transform downRightPoint;
        #endregion

        public string lookingAngle;

        public Animator animator;
        #endregion

        void Update()
        {
            CalibrateWindPower();
            InstantiateWindWave();
        }

        #region Fonctions

        //Assigne la direction ou le vent partira
        void CalibrateWindPower()
        {
            float horizontalDelta;
            float verticalDelta;

            horizontalDelta = Input.GetAxisRaw("Horizontal");
            verticalDelta = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", horizontalDelta);
            animator.SetFloat("Vertical", verticalDelta);

            float angleShoot;
            

            //Vérification que l'input est volontaire
            if (verticalDelta > 0.2 || horizontalDelta > 0.2 || verticalDelta < -0.2 || horizontalDelta < -0.2)
            {
                #region Angles
                //On calcule l'angle en fonction du cos/sin des valeurs du joystick
                angleShoot = Mathf.Atan2(horizontalDelta, verticalDelta);

                if (angleShoot > (Mathf.PI/3) && angleShoot < ((2*Mathf.PI)/3))
                {//RIGHT

                    lookingAngle = ("RIGHT");
                }

                else if (angleShoot > -((2*Mathf.PI)/3) && angleShoot < -(Mathf.PI/3))
                {//LEFT

                    lookingAngle = ("LEFT");
                }

                else if (angleShoot > -(Mathf.PI/6) && angleShoot < (Mathf.PI/6))
                {//TOP

                    lookingAngle = ("TOP");
                }

                else if (angleShoot > ((2*Mathf.PI)/3) && angleShoot < ((5*Mathf.PI)/6))
                {//DOWN RIGHT

                    lookingAngle = ("DOWN RIGHT");
                }

                else if (angleShoot > (Mathf.PI/6) && angleShoot < (Mathf.PI/3))
                {//TOP RIGHT

                    lookingAngle = ("TOP RIGHT");
                }

                else if (angleShoot > -((5*Mathf.PI)/6) && angleShoot < -((2*Mathf.PI)/3))
                {//DOWN LEFT

                    lookingAngle = ("DOWN LEFT");
                }

                else if (angleShoot > -(Mathf.PI/3) && angleShoot < -(Mathf.PI/6))
                {//TOP LEFT

                    lookingAngle = ("TOP LEFT");
                }

                else
                {//DOWN

                    lookingAngle = ("DOWN");
                }
                #endregion
            }
        }

        //Créer la vague en fonction de la direction
        void InstantiateWindWave()
        {
            if (Input.GetButtonDown("WindPower"))//Clique droit
            {

                animator.SetTrigger("CompVersa activated");

                //Instantiation de la vague sur le bon point et dans la bonne direction en fonction du dernier angle enregistré par le joystick
                switch (lookingAngle)
                {


                    //C'est la que y'as tous les commentaires
                    case ("TOP"):

                        GameObject WindWaveT;
                        //Sélectionne le pouvoir en fonction du niveau du pouvoir
                        switch(GameManager.Instance.powerState)
                        {
                            case (1):
                                //Instancie le pouvoir
                                WindWaveT = Instantiate(WindPowerPrefab, topPoint.position, topPoint.rotation);
                                //Donne la direction
                                WindWaveT.GetComponent<WindPower>().WaveDirection.y = 1;
                                break;
                            case (2):
                                WindWaveT = Instantiate(FrozenPowerPrefab, topPoint.position, topPoint.rotation);
                                WindWaveT.GetComponent<WindPower>().WaveDirection.y = 1;
                                break;
                            case (3):
                                WindWaveT = Instantiate(PowerPowerPrefab, topPoint.position, topPoint.rotation);
                                WindWaveT.GetComponent<WindPower>().WaveDirection.y = 1;
                                break;
                        }
                        
                        break;




                    case ("DOWN"):
                        GameObject WindWaveD;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveD = Instantiate(WindPowerPrefab, downPoint.position, downPoint.rotation);
                                WindWaveD.GetComponent<WindPower>().WaveDirection.y = (-1);
                                break;
                            case (2):
                                WindWaveD = Instantiate(FrozenPowerPrefab, downPoint.position, downPoint.rotation);
                                WindWaveD.GetComponent<WindPower>().WaveDirection.y = (-1);
                                break;
                            case (3):
                                WindWaveD = Instantiate(PowerPowerPrefab, downPoint.position, downPoint.rotation);
                                WindWaveD.GetComponent<WindPower>().WaveDirection.y = (-1);
                                break;
                        }
                        
                        break;




                    case ("LEFT"):
                        GameObject WindWaveL;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveL = Instantiate(WindPowerPrefab, leftPoint.position, leftPoint.rotation);
                                WindWaveL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                break;
                            case (2):
                                WindWaveL = Instantiate(FrozenPowerPrefab, leftPoint.position, leftPoint.rotation);
                                WindWaveL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                break;
                            case (3):
                                WindWaveL = Instantiate(PowerPowerPrefab, leftPoint.position, leftPoint.rotation);
                                WindWaveL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                break;
                        }

                        break;




                    case ("RIGHT"):
                        GameObject WindWaveR;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveR = Instantiate(WindPowerPrefab, rightPoint.position, rightPoint.rotation);
                                WindWaveR.GetComponent<WindPower>().WaveDirection.x = 1;
                                break;
                            case (2):
                                WindWaveR = Instantiate(FrozenPowerPrefab, rightPoint.position, rightPoint.rotation);
                                WindWaveR.GetComponent<WindPower>().WaveDirection.x = 1;
                                break;
                            case (3):
                                WindWaveR = Instantiate(PowerPowerPrefab, rightPoint.position, rightPoint.rotation);
                                WindWaveR.GetComponent<WindPower>().WaveDirection.x = 1;
                                break;
                        }
                        
                        break;



                    //
                    case ("TOP LEFT"):
                        GameObject WindWaveTL;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveTL = Instantiate(WindPowerPrefab, topLeftPoint.position, topLeftPoint.rotation);
                                //Normalise la vitesse
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (2):
                                WindWaveTL = Instantiate(FrozenPowerPrefab, topLeftPoint.position, topLeftPoint.rotation);
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (3):
                                WindWaveTL = Instantiate(PowerPowerPrefab, topLeftPoint.position, topLeftPoint.rotation);
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveTL.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                        }
                        
                        break;




                    case ("TOP RIGHT"):
                        GameObject WindWaveTR;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveTR = Instantiate(WindPowerPrefab, topRightPoint.position, topRightPoint.rotation);
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (2):
                                WindWaveTR = Instantiate(FrozenPowerPrefab, topRightPoint.position, topRightPoint.rotation);
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (3):
                                WindWaveTR = Instantiate(PowerPowerPrefab, topRightPoint.position, topRightPoint.rotation);
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveTR.GetComponent<WindPower>().WaveDirection.y = 1;
                                WindWaveTR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                        }

                        break;




                    case ("DOWN LEFT"):
                        GameObject WindWaveDL;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveDL = Instantiate(WindPowerPrefab, downLeftPoint.position, downLeftPoint.rotation);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (2):
                                WindWaveDL = Instantiate(FrozenPowerPrefab, downLeftPoint.position, downLeftPoint.rotation);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (3):
                                WindWaveDL = Instantiate(PowerPowerPrefab, downLeftPoint.position, downLeftPoint.rotation);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.x = (-1);
                                WindWaveDL.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDL.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                        }

                        break;




                    case ("DOWN RIGHT"):
                        GameObject WindWaveDR;
                        switch (GameManager.Instance.powerState)
                        {
                            case (1):
                                WindWaveDR = Instantiate(WindPowerPrefab, downRightPoint.position, downRightPoint.rotation);
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (2):
                                WindWaveDR = Instantiate(FrozenPowerPrefab, downRightPoint.position, downRightPoint.rotation);
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                            case (3):
                                WindWaveDR = Instantiate(PowerPowerPrefab, downRightPoint.position, downRightPoint.rotation);
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.x = 1;
                                WindWaveDR.GetComponent<WindPower>().WaveDirection.y = (-1);
                                WindWaveDR.GetComponent<WindPower>().power /= Mathf.Sqrt(2);
                                break;
                        }

                        break;



                }
            }
        }

        #endregion
    }
}