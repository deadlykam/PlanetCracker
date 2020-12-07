using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.ScriptableObjects.Others;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoadManagerHelper _sceneLoadManager;
        [SerializeField] private PlayerInfo _playerInfo;

        public void BtnStart()
        {
            _playerInfo.ResetValue();
            _sceneLoadManager.LoadStage();
        }

        public void BtnExit() => Application.Quit();
    }
}