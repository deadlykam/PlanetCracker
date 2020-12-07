using System;

namespace PlanetCracker.States
{
    public class CallOnceState : State
    {
        private Action _callBack; // Delegate to call once

        /// <summary>
        /// Creating PermanentState, setting next state and toString value.
        /// </summary>
        /// <param name="stateMachine">The state machine for the states, of type
        ///                            StateMachine</param>
        /// <param name="nextState">The next state to call once state is done,
        ///                         of type State</param>
        /// <param name="toStringValue">The toString value to show when .ToString()
        ///                             is called, of type string</param>
        /// <param name="callBack">The delegate to call once before state change,
        ///                        of type Action</param>
        public CallOnceState(StateMachine stateMachine, State nextState,
                             string toStringValue, Action callBack)
            : base(stateMachine, nextState, toStringValue) => _callBack = callBack;

        /// <summary>
        /// Creating PermanentState, setting next state and toString value.
        /// </summary>
        /// <param name="stateMachine">The state machine for the states, of type
        ///                            StateMachine</param>
        /// <param name="toStringValue">The toString value to show when .ToString()
        ///                             is called, of type string</param>
        /// <param name="callBack">The delegate to call once before state change,
        ///                        of type Action</param>
        public CallOnceState(StateMachine stateMachine, string toStringValue,
                             Action callBack)
            : this(stateMachine, null, toStringValue, callBack)
        {
        }

        public override void Update()
        {
            _callBack.Invoke(); // Calling delegate
            NextState(); // Going to next state
        }
    }
}