using PlanetCracker.Managers;
using PlanetCracker.States;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "StageStateManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "StageStateManagerHelper",
                     order = 1)]
    public class StageStateManagerHelper : BaseManagerHelper<StageStateManager>
    {
        /// <summary>
        /// This method adds a state.
        /// </summary>
        /// <param name="key">The key of the state, of type string</param>
        /// <param name="state">The state to add, of type StageState</param>
        public void AddState(string key, ref State state)
            => manager?.AddState(key, ref state);

        public override void RemoveManager() => manager = null;
    }
}