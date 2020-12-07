namespace PlanetCracker.States
{
    public abstract class State
    {
        protected StateMachine stateMachine;
        private State _nextState;
        private string _toStringValue;

        /// <summary>
        /// Constructor for creating State, setting up the next state and 
        /// giving unique toString value.
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <param name="nextState"></param>
        /// <param name="toStringValue"></param>
        public State(StateMachine stateMachine, State nextState, string toStringValue)
        {
            this.stateMachine = stateMachine;
            _nextState = nextState;
            _toStringValue = toStringValue;
        }

        /// <summary>
        /// Starts next state.
        /// </summary>
        protected virtual void NextState() 
            => stateMachine.SetState(_nextState); // Calling the state

        /// <summary>
        /// This method sets the next state of this state.
        /// </summary>
        /// <param name="state">The state to set as next state, of type State</param>
        public virtual void SetNextState(State state) => _nextState = state;

        public override string ToString() => _toStringValue;

        /// <summary>
        /// To update the state each frame.
        /// </summary>
        public abstract void Update();
    }
}