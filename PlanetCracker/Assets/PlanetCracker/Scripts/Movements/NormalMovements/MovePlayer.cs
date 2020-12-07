using PlanetCracker.NormalizedValues;
using UnityEngine;

namespace PlanetCracker.Movements.NormalMovements
{
    public class MovePlayer : MoveForward
    {
        private INormalValue _accelerate;
        private bool _isMove = false;

        private void Awake() => _accelerate = transform.GetComponent<AccelerateValue>();

        public override void Move(Transform target, float speed)
        {
            // Condition for moving the player forward
            if (Input.GetKey(KeyCode.W))
            {
                _accelerate.Accelerate();
                if (!_isMove) _isMove = true;
            }
            else
            {
                _accelerate.Decelerate(); // Stopping the player movement
                if (_isMove) _isMove = false;
            }
            base.Move(target, speed * _accelerate.GetNormalValue());
        }

        public override bool IsMoving() => _isMove;
    }
}