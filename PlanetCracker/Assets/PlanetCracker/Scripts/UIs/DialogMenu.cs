using PlanetCracker.Managers;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using TMPro;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class DialogMenu : BaseCanvasMenu
    {
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private string[] _dialogs;

        private int _index = 0;
        private State _waitDialog;
        private State _hideDialog;

        private void Start()
        {
            if (_dialogs.Length != 0)
            {
                _dialogText.text = _dialogs[0];
                _index = 1;
            }

            _waitDialog = new FlagCheckState(_stageStateManager.GetManager(), 
                                             StageStateManager.WaitDialog, 
                                             IsDialogDone, true);

            _hideDialog = new CallOnceState(_stageStateManager.GetManager(),
                                            StageStateManager.HideDialog,
                                            HideMenu);

            _stageStateManager.AddState(StageStateManager.WaitDialog, ref _waitDialog);
            _stageStateManager.AddState(StageStateManager.HideDialog, ref _hideDialog);
        }

        private bool IsDialogDone() => _index >= _dialogs.Length;

        public void BtnNext()
        {
            if (!IsDialogDone())
            {
                _dialogText.text = _dialogs[_index];
                _index++;
            }
        }

        public void BtnSkip() => _index = _dialogs.Length;
    }
}