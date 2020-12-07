using PlanetCracker.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Timers
{
    public class TimerCountDown : MonoBehaviour, ITimer
    {
        [Header("Global Properties")]
        [SerializeField] private FloatVariable _simulationSpeed;

        private float _timeSeconds;
        private float _currentTimeSeconds;

        /// <summary>
        /// Getting the dependency fps value from SuperManager, of type float
        /// </summary>
        private float _fps => _simulationSpeed.GetValue() * Time.deltaTime;

        /// <summary>
        /// This method sets up the countdown timer.
        /// </summary>
        /// <param name="timeSeconds">The countdown time to set in seconds,
        ///                           of type float</param>
        public void StartSetup(float timeSeconds)
        {
            _timeSeconds = timeSeconds; // Setting the countdown timer
            _currentTimeSeconds = 0f;   // Resetting timer
        }

        /// <summary>
        /// This method stops the timer
        /// </summary>
        public void StopTimer() => _currentTimeSeconds = 0f;

        /// <summary>
        /// This method updates the count down timer.
        /// </summary>
        public void UpdateTimer()
        {
            // Condition for counting down
            if (_currentTimeSeconds != 0f) _currentTimeSeconds =
                                                _currentTimeSeconds - _fps <= 0 ?
                                                0 :
                                                _currentTimeSeconds - _fps;
        }

        /// <summary>
        /// This method resets the countdown timer ONLY if the countdown
        /// has finished.
        /// </summary>
        public void ResetTimer()
            => _currentTimeSeconds = _currentTimeSeconds == 0f ?
                                        _timeSeconds :
                                        _currentTimeSeconds;

        /// <summary>
        /// This method checks if the count down timer is set to start value.
        /// </summary>
        /// <returns>Flag to check if the timer has been set to start value,
        ///          of type bool</returns>
        public bool IsTimerStart() => _currentTimeSeconds == _timeSeconds;

        /// <summary>
        /// This method checks if the count down timer is done.
        /// </summary>
        /// <returns>The flag that checks if the timer is done, of type bool</returns>
        public bool IsTimerDone() => _currentTimeSeconds == 0;

        /// <summary>
        /// The normalized value of the progress.
        /// </summary>
        /// <returns>The normalized value of the progress from 0 - 1, of type float</returns>
        public float TimerProgress() => 1 - _currentTimeSeconds / _timeSeconds;
    }
}