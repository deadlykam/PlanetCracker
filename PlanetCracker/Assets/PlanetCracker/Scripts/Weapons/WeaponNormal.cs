using PlanetCracker.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Weapons
{
    [RequireComponent(typeof(TimerCountDown))]
    public class WeaponNormal : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletHolder;
        [SerializeField] private Transform _genPoint; // Bullet generation point
        [SerializeField] private float _speedBullet;
        [SerializeField] private int _damageBullet;
        [SerializeField] private float _fireRate;
        [SerializeField] private string _targetTag;

        private List<IBullet> _bullets;
        private int _indexBullet;
        
        private ITimer _fireRateTimer;

        protected virtual void Awake()
        {
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

        protected virtual void Update()
        {
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

        public int GetBulletDamage() => _damageBullet;
        public float GetBulletSpeed() => _speedBullet;
        public string GetTargetTag() => _targetTag;
    }
}