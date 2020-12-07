using PlanetCracker.Timers;
using UnityEngine;

namespace PlanetCracker.Others
{
    [RequireComponent(typeof(TimerCountDown))]
    public class HideSelf : MonoBehaviour
    {
        [SerializeField] private float _hideSeconds;

        private ITimer _timer;

        private void Awake()
        {
            _timer = GetComponent<ITimer>();
            _timer.StartSetup(_hideSeconds);
        }

        private void OnEnable() => _timer.ResetTimer();

        private void Update()
        {
            if (!_timer.IsTimerDone()) _timer.UpdateTimer();
            else gameObject.SetActive(false);
        }
    }
}