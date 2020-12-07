using PlanetCracker.ScriptableObjects.Delegates;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class InteractiveMenu : BaseCanvasMenu
    {
        [SerializeField] private ActionNormal0 _interactiveShow;
        [SerializeField] private ActionNormal0 _interactiveHide;

        private void OnEnable()
        {
            _interactiveShow.SetDelegate(ShowMenu);
            _interactiveHide.SetDelegate(HideMenu);
        }

        private void OnDisable()
        {
            _interactiveShow.RemoveDelegate();
            _interactiveHide.RemoveDelegate();
        }
    }
}