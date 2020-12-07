using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.NormalizedValues
{
    public class AccelerateValue : MonoBehaviour, INormalValue
    {
        [SerializeField] private FloatVariable _simulationSpeed;
        [SerializeField] private float _accelerate;

        private float _value = 0; // The normal value

        protected float fps => Time.deltaTime * _accelerate * _simulationSpeed.GetValue();

        public void SetNormalValue(float value) 
            => _value = value > 1 ? 1 : value < 0 ? 0 : value;

        public void Accelerate() => _value = _value + fps >= 1 ? 1 : _value + fps;
        public void Decelerate() => _value = _value - fps <= 0 ? 0 : _value - fps;
        public float GetNormalValue() => _value;
    }
}