using PlanetCracker.ScriptableObjects.Delegates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Cameras
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3Func0 _playerPosition;

        private Vector3 _cameraOffset;
        private Vector3 _newPosition;

        private void Start()
            => _cameraOffset = transform.position - _playerPosition.GetValue();

        private void LateUpdate()
        {
            // Getting new position
            _newPosition = _playerPosition.GetValue() + _cameraOffset;
            transform.position = _newPosition; // Setting the camera position
        }
    }
}