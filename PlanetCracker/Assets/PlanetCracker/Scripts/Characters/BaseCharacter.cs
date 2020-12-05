using PlanetCracker.Movements.NormalMovements;
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

        protected virtual void Awake() => InitCharacter();
        
        protected virtual void Update()
        {
            _movement.Move(transform, _speedMove);
        }

        /// <summary>
        /// This method sets up the character.
        /// </summary>
        private void InitCharacter()
        {
            _movement = transform.GetComponent<IMove>();
        }
    }
}