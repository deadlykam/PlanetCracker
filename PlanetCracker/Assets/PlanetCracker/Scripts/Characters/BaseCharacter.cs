using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using PlanetCracker.Weapons;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [Header("Base Properties")]
        [SerializeField] private Transform _weaponModel;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRot;

        private IMove _movement;
        private IRotate _rotate;
        private IWeapon _weapon;

        protected virtual void Awake() => InitCharacter();
        
        protected virtual void Update()
        {
            _movement.Move(transform, _speedMove);
            _rotate.Rotate(transform, _speedRot);
        }

        /// <summary>
        /// This method sets up the character.
        /// </summary>
        private void InitCharacter()
        {
            _movement = transform.GetComponent<IMove>();
            _rotate = transform.GetComponent<IRotate>();
            _weapon = _weaponModel.GetComponent<IWeapon>();
        }

        /// <summary>
        /// This method fires the weapon.
        /// </summary>
        protected void FireWeapon() => _weapon?.Fire();

        /// <summary>
        /// The world position of the character.
        /// </summary>
        /// <returns>The world position of the character, of type Vector3</returns>
        public Vector3 GetPosition() => transform.position;
    }
}