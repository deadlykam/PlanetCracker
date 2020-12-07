using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.ScriptableObjects.Others;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoadManagerHelper _sceneLoadManager;
        [SerializeField] private MusicManagerHelper _musicManager;
        [SerializeField] private PlayerInfo _playerInfo;

        private void Start() => _musicManager.PlayMainMenuMusic();

        public void BtnStart()
        {
            _playerInfo.ResetValue();
            _musicManager.PlayGameplayMusic();
            _sceneLoadManager.LoadStage();
        }

        public void BtnExit() => Application.Quit();
    }
}