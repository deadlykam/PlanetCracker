using PlanetCracker.NormalizedValues;
using PlanetCracker.ScriptableObjects.Delegates;
using UnityEngine;

namespace PlanetCracker.Movements.NormalMovements
{
    public class MoveEnemy : MoveForward
    {
        [SerializeField] private Vector3Func0 _playerPosition;
        [SerializeField] private float _distThreshold;

        private INormalValue _accelerate;

        private void Awake() => _accelerate = transform.GetComponent<AccelerateValue>();

        private bool IsMove() 
            => Vector3.Distance(transform.position, _playerPosition.GetValue())
                > _distThreshold;

        public override void Move(Transform target, float speed)
        {
            // Condition for moving the enemy
            if (IsMove()) _accelerate.Accelerate();
            else _accelerate.Decelerate();

            base.Move(target, speed * _accelerate.GetNormalValue());
        }

        public override bool IsMoving() => IsMove();
    }
}