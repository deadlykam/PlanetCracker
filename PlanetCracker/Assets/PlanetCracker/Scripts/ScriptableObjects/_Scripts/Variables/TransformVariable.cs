using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "TransformVariable",
                     menuName = "PlanetCracker/ScriptableObject/Variables/TransformVariable",
                     order = 1)]
    public class TransformVariable : BaseVariable<Transform>
    {
        public override void ResetScript() => value = null;
        protected override Transform GetDefaultValue() => null;
        protected override bool IsValueNull() => false;
    }
}