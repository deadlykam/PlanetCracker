using PlanetCracker.NormalizedValues;
using UnityEngine;

namespace PlanetCracker.Movements.NormalMovements
{
    public class MovePlayer : MoveForward
    {
        private INormalValue _accelerate;

        private void Awake() => _accelerate = transform.GetComponent<AccelerateValue>();

        public override void Move(Transform target, float speed)
        {
            // Condition for moving the player forward
            if (Input.GetKey(KeyCode.W)) _accelerate.Accelerate();
            else _accelerate.Decelerate(); // Stopping the player movement
            base.Move(target, speed * _accelerate.GetNormalValue());
        }
    }
}