using PlanetCracker.Managers;
using PlanetCracker.NormalizedValues;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using PlanetCracker.Timers;
using UnityEngine;

namespace PlanetCracker.GiantAxes
{
    [RequireComponent(typeof(AccelerateValue), typeof(TimerCountDown))]
    public class GiantAxe : MonoBehaviour
    {
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private Transform _model;
        [SerializeField] private float _waitTimer;
        [SerializeField] private float _degree;

        private AccelerateValue _accelerate;
        private ITimer _timer;
        private Quaternion _swingDegree;
        private bool _isSwingAxe = false;
        private State _showAxe;
        private State _waitShowAxe;
        private State _swingAxe;
        private State _waitSwingAxe;

        private void Awake()
        {
            _accelerate = GetComponent<AccelerateValue>();
            _swingDegree = Quaternion.Euler(_degree, 0, 0);
            _timer = GetComponent<ITimer>();
            _timer.StartSetup(_waitTimer);
        }

        private void Start()
        {
            _showAxe = new CallOnceState(_stageStateManager.GetManager(), 
                                         StageStateManager.ShowAxe, 
                                         ShowAxe);

            _waitShowAxe = new FlagCheckState(_stageStateManager.GetManager(),
                                               StageStateManager.WaitShowAxe,
                                               _timer.IsTimerDone, true);

            _swingAxe = new CallOnceState(_stageStateManager.GetManager(),
                                         StageStateManager.SwingAxe,
                                         SwingAxe);

            _waitSwingAxe = new FlagCheckState(_stageStateManager.GetManager(),
                                               StageStateManager.WaitSwingAxe,
                                               IsAxeSwinging, false);

            _stageStateManager.AddState(StageStateManager.ShowAxe, ref _showAxe);
            _stageStateManager.AddState(StageStateManager.WaitShowAxe, ref _waitShowAxe);
            _stageStateManager.AddState(StageStateManager.SwingAxe, ref _swingAxe);
            _stageStateManager.AddState(StageStateManager.WaitSwingAxe, ref _waitSwingAxe);
        }

        private void Update()
        {
            if (IsAxeSwinging())
            {
                _accelerate.Accelerate();
                _model.rotation = Quaternion.Slerp(Quaternion.identity, 
                                                   _swingDegree, 
                                                   _accelerate.GetNormalValue());
            }

            if (!_timer.IsTimerDone()) _timer.UpdateTimer();
        }

        private bool IsAxeSwinging() => _isSwingAxe && _accelerate.GetNormalValue() != 1f;
        private void SwingAxe() => _isSwingAxe = true;
        private void ShowAxe()
        {
            _model.gameObject.SetActive(true);
            _timer.ResetTimer();
        }
    }
}