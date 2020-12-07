using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Timers
{
    public interface ITimer
    {
        /// <summary>
        /// This method sets up the timer.
        /// </summary>
        /// <param name="timeSeconds">The time to set in seconds, of type float</param>
        void StartSetup(float timeSeconds);

        /// <summary>
        /// This method stops the timer.
        /// </summary>
        void StopTimer();

        /// <summary>
        /// This method updates the timer.
        /// </summary>
        void UpdateTimer();

        /// <summary>
        /// This method resets the timer.
        /// </summary>
        void ResetTimer();

        /// <summary>
        /// This method checks if the timer is set to start value.
        /// </summary>
        /// <returns>Flag to check if the timer has been set to start value,
        ///          of type bool</returns>
        bool IsTimerStart();

        /// <summary>
        /// This method checks if the timer is done.
        /// </summary>
        /// <returns>The flag that checks if the timer is done, of type bool</returns>
        bool IsTimerDone();

        /// <summary>
        /// The normalized value of the progress.
        /// </summary>
        /// <returns>The normalized value of the progress from 0 - 1, of type float</returns>
        float TimerProgress();
    }
}