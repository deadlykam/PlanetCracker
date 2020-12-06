using UnityEngine;

namespace PlanetCracker.States
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State currentState; // The current state
        private bool _isDebug; // Flag to enable/disable debug

        protected virtual void Update()
        {
            // Condition for showing the current state when debug enabled
            if (_isDebug) Debug.Log(currentState?.ToString());
            currentState?.Update(); // Updating the state
        }

        /// <summary>
        /// This method sets a state for the state machine.
        /// </summary>
        /// <param name="state">The state to set, of type State</param>
        public void SetState(State state) => currentState = state;

        /// <summary>
        /// This method checks if all states have played out.
        /// </summary>
        /// <returns>True means all state playing done, false otherwise, 
        ///          of type bool</returns>
        public virtual bool IsProcessDone() => currentState == null;

        [ContextMenu("Enable Debug")]
        /// <summary>
        /// This method enables the debug.
        /// </summary>
        public void EnableDebug() => _isDebug = true;

        [ContextMenu("Disable Debug")]
        /// <summary>
        /// This method disables the debug.
        /// </summary>
        public void DisableDebug() => _isDebug = false;
    }
}