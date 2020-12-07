using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Delegates
{
    [CreateAssetMenu(fileName = "Vector3Func0",
                     menuName = "PlanetCracker/ScriptableObject/Delegates/" +
                                "Vector3Func0",
                     order = 1)]
    public class Vector3Func0 : BaseFunc0<Vector3>
    {
        private Vector3 _defaultValue = Vector3.zero; // Default value

        public override Vector3 GetValue()
        {
            if (!HasReturner()) return _defaultValue; // Delegate not set, return default
            return base.GetValue(); // Delegate set, return value
        }

        public override void ResetScript() => returner = null;
    }
}