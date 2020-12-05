using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable",
                     menuName = "PlanetCracker/ScriptableObject/Variables/FloatVariable",
                     order = 1)]
    public class FloatVariable : BaseVariable<float>
    {
        private float _defaultValue = 0f; // The default value

        protected override float GetDefaultValue() => _defaultValue;
        protected override bool IsValueNull() => false;
        public override void ResetScript() => value = _defaultValue;
    }
}