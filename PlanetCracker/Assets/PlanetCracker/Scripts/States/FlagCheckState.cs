using System;

namespace PlanetCracker.States
{
    public class FlagCheckState : State
    {
        private Func<bool> _isActivated; // Delegate giving flag result
        private bool _isCheck; // Flag to check which result from _isActivated to check for

        /// <summary>
        /// Creating FlagCheckState, setting next state and toString value.
        /// </summary>
        /// <param name="stateMachine">The state machine for the states, of type
        ///                            StateMachine</param>
        /// <param name="nextState">The next state to call once state is done,
        ///                         of type State</param>
        /// <param name="toStringValue">The toString value to show when .ToString()
        ///                             is called, of type string</param>
        /// <param name="isActivated">Delegate to get the flag result from which will 
        ///                           determine if to go to the next state,
        ///                           of type Func<bool></param>
        /// <param name="isCheck">Flag to check if the true or false value will be
        ///                       used from the delegate to progress to the next state,
        ///                       true means true value will be used false otherwise,
        ///                       of type bool</param>
        public FlagCheckState(StateMachine stateMachine, State nextState,
                              string toStringValue, Func<bool> isActivated, bool isCheck)
            : base(stateMachine, nextState, toStringValue)
        {
            _isActivated = isActivated;
            _isCheck = isCheck;
        }

        /// <summary>
        /// Creating FlagCheckState, setting next state and toString value.
        /// </summary>
        /// <param name="stateMachine">The state machine for the states, of type
        ///                            StateMachine</param>
        /// <param name="nextState">The next state to call once state is done,
        ///                         of type State</param>
        /// <param name="isActivated">Delegate to get the flag result from which will 
        ///                           determine if to go to the next state,
        ///                           of type Func<bool></param>
        /// <param name="isCheck">Flag to check if the true or false value will be
        ///                       used from the delegate to progress to the next state,
        ///                       true means true value will be used false otherwise,
        ///                       of type bool</param>
        public FlagCheckState(StateMachine stateMachine, string toStringValue,
                              Func<bool> isActivated, bool isCheck)
            : this(stateMachine, null, toStringValue, isActivated, isCheck)
        {
        }

        public override void Update()
        {
            if (_isCheck) // Condition to check for the true result
            {
                // Condition to go to next state
                if (_isActivated.Invoke()) NextState();
            }
            else // Condition to check for the false result
            {
                // Condition to go to next state
                if (!_isActivated.Invoke()) NextState();
            }
        }
    }
}