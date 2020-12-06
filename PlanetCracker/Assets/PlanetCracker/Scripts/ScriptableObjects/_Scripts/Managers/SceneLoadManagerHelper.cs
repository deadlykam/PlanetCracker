using PlanetCracker.Managers;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "SceneLoadManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "SceneLoadManagerHelper",
                     order = 1)]
    public class SceneLoadManagerHelper : BaseManagerHelper<SceneLoadManager>
    {
        public void LoadStage() => manager?.LoadStage();
        public override void RemoveManager() => manager = null;
    }
}