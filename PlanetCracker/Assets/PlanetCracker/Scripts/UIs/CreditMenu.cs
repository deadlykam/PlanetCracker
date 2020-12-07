using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class CreditMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoadManagerHelper _sceneLoadManager;

        public void BtnMainMenu() => _sceneLoadManager.LoadMainMenu();
    }
}