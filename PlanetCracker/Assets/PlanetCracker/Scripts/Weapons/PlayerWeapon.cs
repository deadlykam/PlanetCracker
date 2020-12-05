using PlanetCracker.Rotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public class PlayerWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private float _speedRotate;

        private IRotate _rotate; // For rotating the turret

        private void Awake() => _rotate = transform.GetComponent<IRotate>();

        private void Update() => _rotate.Rotate(transform, _speedRotate);

        public void Fire() => Debug.Log("Hoga Firing!");
    }
}