using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using UnityEngine;

namespace PlanetCracker.Managers
{
    public class InGameMenuManager : MonoBehaviour
    {
        [SerializeField] private InGameMenuManagerHelper _helper;
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private ActionNormal0 _interactiveShow;
        [SerializeField] private ActionNormal0 _interactiveHide;

        private State _showInteractive;
        private State _waitPressE;
        private State _hideInteractive;

        private void Awake() => _helper.SetManager(this);
        private void OnDisable() => _helper.RemoveManager();

        private void Start()
        {
            _showInteractive = new CallOnceState(_stageStateManager.GetManager(),
                                                 StageStateManager.ShowInteractive,
                                                 ShowInteractiveMenu);

            _waitPressE = new PressEState(_stageStateManager.GetManager(),
                                          null,
                                          StageStateManager.WaitPressE);

            _hideInteractive = new CallOnceState(_stageStateManager.GetManager(),
                                                 StageStateManager.HideInteractive,
                                                 HideInteractiveMenu);

            _stageStateManager.AddState(StageStateManager.ShowInteractive, 
                                        ref _showInteractive);

            _stageStateManager.AddState(StageStateManager.WaitPressE, ref _waitPressE);

            _stageStateManager.AddState(StageStateManager.HideInteractive,
                                        ref _hideInteractive);
        }

        public void ShowInteractiveMenu() => _interactiveShow.CallAction();
        public void HideInteractiveMenu() => _interactiveHide.CallAction();
    }
}