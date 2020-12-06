using PlanetCracker.Managers;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "InGameMenuManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "InGameMenuManagerHelper",
                     order = 1)]
    public class InGameMenuManagerHelper : BaseManagerHelper<InGameMenuManager>
    {
        public void ShowInteractiveMenu() => manager?.ShowInteractiveMenu();
        public void HideInteractiveMenu() => manager?.HideInteractiveMenu();
        public override void RemoveManager() => manager = null;
    }
}