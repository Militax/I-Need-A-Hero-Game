using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;
using UnityEngine.SceneManagement;
using Player;


namespace GameManagement
{
    /// <summary>
    /// General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        #region Player Variable
        [HideInInspector]
        public bool HasKey;
        public Vector3 RespawnPoint;
        public Vector3 RespawnPointVide;
        public PlayerMovement player;
        public bool playerCanMove;
        public bool invulnerability;
        public float invulnerabilityduration;

        #region Health
        public int DeathCounter;
        public int playerHealth;
        public int playerHealthMax;
        
        #endregion
        #region Power
        public int powerState;
        /*
        1.WindWave
        2.FrozenWave
        3.PowerWave
        */
        #endregion
        #region Damages
        public int swordDamage;
        public int SlamDamage;
        #endregion

        #endregion

        #region Economic Variable and Object

        public int CoinOwned;
		public int maxCoin;

        #endregion

		#region ShopVariable

		public int bottesState;


        #endregion

        public bool isComingFromDonjon = false;

        [HideInInspector]
        public string currentSave = null;
        void Awake()
        {
            MakeSingleton(true);
            GameInitialisation();
        }

        private void Update()
        {
            if (invulnerability == true)
            {
                StartCoroutine(resetinvulnerability());
            }
        }

        IEnumerator resetinvulnerability()
        {
            yield return new WaitForSeconds(invulnerabilityduration);
            invulnerability = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(RespawnPoint, 0.2f);
        }

        #region "Getters/Setters"
        public void SetHealth(int health, int max)
        {
            Instance.playerHealth = health;
            Instance.playerHealthMax = max;
        }
        #endregion


        //Initialisation de la valeur des différentes variables
        void GameInitialisation()
        {
            #region Player

            playerCanMove = true;

            playerHealth = playerHealthMax;
            powerState = 0;

            swordDamage = 1;
            SlamDamage = 3;
            #endregion

            #region Economic

            CoinOwned = 0; 
			maxCoin = 1000;

            #endregion

			#region Shop

			bottesState = 0;
		

			#endregion
        }


        public void loot(int _numberOfDrops, float _lootRange, GameObject[] _lootArray, GameObject _instance)
        {
            for (int i = 0; i < _numberOfDrops; i++)
            {
                int rnd = Random.Range(0, _lootArray.Length);
                float range = Random.Range(-_lootRange, _lootRange);
                if (_lootArray[i] != null)
                {
                    //Debug.Log("BIM CA LOUTTE");
                    Instantiate(_lootArray[rnd], _instance.transform.position + new Vector3(range, range, 0), Quaternion.identity);
                }
                
            }
        }
    }
}