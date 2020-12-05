using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [Header("Base Properties")]
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRot;

        private IMove _movement;
        private IRotate _rotate;

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
        }

        /// <summary>
        /// The world position of the character.
        /// </summary>
        /// <returns>The world position of the character, of type Vector3</returns>
        public Vector3 GetPosition() => transform.position;
    }
}