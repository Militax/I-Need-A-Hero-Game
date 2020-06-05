using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

public class CatBehaviourProto : MonoBehaviour
{
    #region References
    PlayerMovement player;
    #endregion

    #region Variables

    float distance;

    [Header("Movement")]
    public float speed;
    public float detectionRange;

    [Header("Attack")]
    public int Damage;
    public float AttackRange;

    #endregion

    void Start()
    {
        player = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(gameObject.transform.position, player.transform.position);




    }

    void Attack()
    {

    }

    

}
