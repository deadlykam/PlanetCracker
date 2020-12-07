using PlanetCracker.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("GameManager Global Properties")]
        [SerializeField] private FloatVariable _simulationSpeed;
        [SerializeField] private TransformVariable _bulletContainer;

        [Header("GameManager Local Properties")]
        [SerializeField, Range(0f, 1f)] private float _simSpeed;
        [SerializeField] private Transform _bulletHolder;

        private void Awake()
        {
            _simulationSpeed.SetValue(_simSpeed);
            _bulletContainer.SetValue(_bulletHolder);
        }

        private void Update()
        {
            // Checking if the simulation speed has not been updated
            if (_simSpeed != _simulationSpeed.GetValue())
                _simulationSpeed.SetValue(_simSpeed);
        }
    }
}