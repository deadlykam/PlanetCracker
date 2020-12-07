using PlanetCracker.Managers;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using PlanetCracker.Timers;
using UnityEngine;

namespace PlanetCracker.Cameras
{
    [RequireComponent(typeof(TimerCountDown))]
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private float _timeSeconds; // Amount of time for shake
        [SerializeField] private float _force; // The maximum force of the shake

        private Vector3 _originalPos; // The original position
        private Vector3 _shakePos; // The shake position
        private float _magnitude; // The magnitude of the shake, 0 - 1
        private ITimer _timer;
        private State _shakeCamera;

        private void Awake()
        {
            _timer = GetComponent<ITimer>();
            _timer.StartSetup(_timeSeconds);

            _originalPos = transform.localPosition; // Storing the original position
            _shakePos = Vector3.zero;
            _magnitude = 0;
        }

        private void Start()
        {
            _shakeCamera = new CallOnceState(_stageStateManager.GetManager(), 
                                             StageStateManager.ShakeCamera, ShakeCamera);

            _stageStateManager.AddState(StageStateManager.ShakeCamera, ref _shakeCamera);
        }

        private void Update()
        {
            if (!_timer.IsTimerDone()) // Condition for shaking the camera
            {
                // Setting the shake position
                _shakePos.Set(Random.Range(-_force, _force) * _magnitude,
                              Random.Range(-_force, _force) * _magnitude,
                              transform.localPosition.z);
                transform.localPosition = _shakePos; // Shaking the camera
                _timer.UpdateTimer(); // Updating the timer

                // Shake effect done resetting the position back to original
                if (_timer.IsTimerDone()) transform.localPosition = _originalPos;
            }
        }

        private void ShakeCamera()
        {
            _timer.ResetTimer(); // Starting the timer
            _shakePos = Vector3.zero; // Resetting the shake position
            _magnitude = 1;
        }
    }
}