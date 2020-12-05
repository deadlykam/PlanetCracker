using PlanetCracker.Rotations;
using System.Collections.Generic;
using UnityEngine;
using PlanetCracker.Timers;

namespace PlanetCracker.Weapons
{
    [RequireComponent(typeof(TimerCountDown))]
    public class PlayerWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletHolder;
        [SerializeField] private Transform _genPoint; // Bullet generation point
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _speedBullet;
        [SerializeField] private float _damageBullet;
        [SerializeField] private float _fireRate;

        private List<IBullet> _bullets;
        private int _indexBullet;

        private IRotate _rotate; // For rotating the turret
        private ITimer _fireRateTimer;

        private void Awake()
        {
            _rotate = GetComponent<IRotate>();
            _bullets = new List<IBullet>();

            _fireRateTimer = GetComponent<ITimer>();
            _fireRateTimer.StartSetup(_fireRate);

            for (_indexBullet = 0; _indexBullet < _bulletHolder.childCount; _indexBullet++)
                _bullets.Add(_bulletHolder.GetChild(_indexBullet).GetComponent<IBullet>());
        }

        private void Start()
        {
            for (_indexBullet = 0; _indexBullet < _bullets.Count; _indexBullet++)
                _bullets[_indexBullet].SetupBullet(this);
        }

        private void Update()
        {
            _rotate.Rotate(transform, _speedRotate);

            if (!_fireRateTimer.IsTimerDone()) _fireRateTimer.UpdateTimer();
        }

        [ContextMenu("Fire Bullet")]
        public void Fire()
        {
            if (_fireRateTimer.IsTimerDone())
            {
                _indexBullet = _indexBullet + 1 >= _bullets.Count ? 0 : _indexBullet + 1;
                _bullets[_indexBullet].FireBullet(_genPoint.position, transform.rotation);
                _fireRateTimer.ResetTimer();
            }
        }

        public float GetBulletDamage() => _damageBullet;
        public float GetBulletSpeed() => _speedBullet;
    }
}