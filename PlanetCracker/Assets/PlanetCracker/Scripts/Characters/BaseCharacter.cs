using PlanetCracker.Healths;
using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using PlanetCracker.Weapons;
using System;
using UnityEngine;

namespace PlanetCracker.Characters
{
    [RequireComponent(typeof(Health))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        [Header("Base Properties")]
        [SerializeField] private Transform[] _weaponModels;
        [SerializeField] private int _maxHealth = 1;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRot;

        private IMove _movement;
        private IRotate _rotate;
        private IWeapon[] _weapons;
        protected IHealth health;
        private Rigidbody _rigidBody;
        private Action _fireWeapon;
        private int _index;

        protected virtual void Awake() => InitCharacter();
        
        protected virtual void Update()
        {
            if (!health.IsDead())
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
            health = GetComponent<IHealth>();
            health.StartSetup(_maxHealth);
            _rigidBody = GetComponent<Rigidbody>();
            _weapons = new IWeapon[_weaponModels.Length];

            for (_index = 0; _index < _weaponModels.Length; _index++)
            {
                _weapons[_index] = _weaponModels[_index].GetComponent<IWeapon>();
                _fireWeapon += _weapons[_index].Fire;
            }
        }

        /// <summary>
        /// This method fires the weapon.
        /// </summary>
        protected void FireWeapon() => _fireWeapon?.Invoke();

        /// <summary>
        /// This method checks if the character has died.
        /// </summary>
        /// <returns>True means dead, false otherwise, of type bool</returns>
        protected bool IsDead() => health.IsDead();

        /// <summary>
        /// This method handles all the death conditions of the character.
        /// </summary>
        protected virtual void Dead() => gameObject.SetActive(false);

        /// <summary>
        /// This method heals the character.
        /// </summary>
        /// <param name="amount">The amount to heal by, of type int</param>
        public virtual void Heal(int amount) => health.Heal(amount);
        
        /// <summary>
        /// This method hurts the character.
        /// </summary>
        /// <param name="amount">The amount to hurt by, of type int</param>
        public virtual void Hurt(int amount) => health.Hurt(amount);

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
        
        public void SetValues(int health, int damage, float speed)
        {
            _maxHealth = health;
            this.health.StartSetup(health);
            _speedMove = speed;
            _speedRot += speed;

            for (_index = 0; _index < _weaponModels.Length; _index++)
                _weapons[_index].SetBulletDamage(damage);
        }
    }
}