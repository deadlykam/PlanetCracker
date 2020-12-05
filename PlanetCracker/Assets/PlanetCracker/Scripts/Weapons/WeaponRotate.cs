using PlanetCracker.Rotations;
using System.Collections.Generic;
using UnityEngine;
using PlanetCracker.Timers;

namespace PlanetCracker.Weapons
{
    [RequireComponent(typeof(TimerCountDown))]
    public class WeaponRotate : WeaponNormal, IWeapon
    {
        [SerializeField] private float _speedRotate;
        private IRotate _rotate; // For rotating the turret

        protected override void Awake()
        {
            base.Awake();
            _rotate = GetComponent<IRotate>();
        }
        
        protected override void Update()
        {
            base.Update();
            _rotate.Rotate(transform, _speedRotate);
        }
    }
}