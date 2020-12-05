using PlanetCracker.Healths;
using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using PlanetCracker.Weapons;
using UnityEngine;

namespace PlanetCracker.Characters
{
    [RequireComponent(typeof(Health))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        [Header("Base Properties")]
        [SerializeField] private Transform _weaponModel;
        [SerializeField] private int _maxHealth = 1;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRot;

        private IMove _movement;
        private IRotate _rotate;
        private IWeapon _weapon;
        private IHealth _health;
        private Rigidbody _rigidBody;

        protected virtual void Awake() => InitCharacter();
        
        protected virtual void Update()
        {
            if (!_health.IsDead())
            {
                _movement.Move(transform, _speedMove);
                _rotate.Rotate(transform, _speedRot);
            }
            else
            {
                if (gameObject.activeSelf) Dead();
            }

            if (_rigidBody.velocity != Vector3.zero)
                _rigidBody.velocity = Vector3.zero;

            if (_rigidBody.angularVelocity != Vector3.zero)
                _rigidBody.angularVelocity = Vector3.zero;
        }

        /// <summary>
        /// This method sets up the character.
        /// </summary>
        private void InitCharacter()
        {
            _movement = GetComponent<IMove>();
            _rotate = GetComponent<IRotate>();
            _weapon = _weaponModel.GetComponent<IWeapon>();
            _health = GetComponent<IHealth>();
            _health.StartSetup(_maxHealth);
            _rigidBody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// This method fires the weapon.
        /// </summary>
        protected void FireWeapon() => _weapon?.Fire();

        /// <summary>
        /// This method checks if the character has died.
        /// </summary>
        /// <returns>True means dead, false otherwise, of type bool</returns>
        protected bool IsDead() => _health.IsDead();

        /// <summary>
        /// This method handles all the death conditions of the character.
        /// </summary>
        protected virtual void Dead() => gameObject.SetActive(false);

        /// <summary>
        /// This method heals the character.
        /// </summary>
        /// <param name="amount">The amount to heal by, of type int</param>
        public void Heal(int amount) => _health.Heal(amount);
        
        /// <summary>
        /// This method hurts the character.
        /// </summary>
        /// <param name="amount">The amount to hurt by, of type int</param>
        public void Hurt(int amount) => _health.Hurt(amount);

        /// <summary>
        /// The world position of the character.
        /// </summary>
        /// <returns>The world position of the character, of type Vector3</returns>
        public Vector3 GetPosition() => transform.position;

        /// <summary>
        /// This method will start the character
        /// </summary>
        /// <param name="position">The positino to start from, of type Vector3</param>
        public void StartCharacter(Vector3 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
        }
    }
}