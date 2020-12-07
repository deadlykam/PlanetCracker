using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class CreditMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoadManagerHelper _sceneLoadManager;
        [SerializeField] private MusicManagerHelper _musicManager;

        private void Start() => _musicManager.PlayMainMenuMusic();
        public void BtnMainMenu() => _sceneLoadManager.LoadMainMenu();
    }
}