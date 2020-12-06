using UnityEngine;

namespace PlanetCracker.States
{
    public class PressEState : State
    {
        public PressEState(StateMachine stateMachine, State nextState, 
            string toStringValue) : base(stateMachine, nextState, toStringValue)
        {
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) NextState();
        }
    }
}