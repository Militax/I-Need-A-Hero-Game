using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class BossCamera : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Transform _bossTransform;
    [SerializeField]
    private float START_SIZE = 10f;
    [SerializeField]
    private float MAX_SIZE = 20f;
    [SerializeField]
    private float MIN_SIZE = 5f;
    [SerializeField]
    private float _multiplierSize = 1f;
    [SerializeField]
    private float _cameraTranslationMultiplier = 10f;

    private Camera _camera;
    private Vector3 START_POSITION;
    #endregion

    private void Start()
    {
        START_POSITION = transform.position;
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = START_SIZE;
    }

    private void Update()
    {
        float newCameraSize = Vector2.Distance(_playerTransform.position, _bossTransform.position) * _multiplierSize;
        _camera.orthographicSize = Mathf.Clamp(newCameraSize, MIN_SIZE, MAX_SIZE);
        transform.position =  (MAX_SIZE - _camera.orthographicSize) * _cameraTranslationMultiplier * Vector3.up + START_POSITION;
        
    }
}
