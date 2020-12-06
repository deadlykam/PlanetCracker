using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class DeathMenu : BaseCanvasMenu
    {
        [SerializeField] private SceneLoadManagerHelper _sceneLoadManager;
        [SerializeField] private ActionNormal0 _deathMenuShow;

        private void OnEnable() => _deathMenuShow.SetDelegate(ShowMenu);
        private void OnDisable() => _deathMenuShow.RemoveDelegate();

        public void BtnLoadMainMenu() => _sceneLoadManager.LoadMainMenu();
    }
}