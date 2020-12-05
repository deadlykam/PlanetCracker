using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "EnemyManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "EnemyManagerHelper",
                     order = 1)]
    public class EnemyManagerHelper : BaseManagerHelper<EnemyManager>
    {
        /// <summary>
        /// This method counts when an enemy has died.
        /// </summary>
        public void EnemyDied() => manager?.EnemyDied();
    }
}