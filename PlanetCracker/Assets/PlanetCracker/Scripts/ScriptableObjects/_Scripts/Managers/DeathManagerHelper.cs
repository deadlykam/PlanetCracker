using UnityEngine;
using PlanetCracker.Managers;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "DeathManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "DeathManagerHelper",
                     order = 1)]
    public class DeathManagerHelper : BaseManagerHelper<DeathManager>
    {
        public void RequestExplosion(Vector3 position) 
            => manager?.RequestExplosion(position);

        public override void RemoveManager() => manager = null;
    }
}