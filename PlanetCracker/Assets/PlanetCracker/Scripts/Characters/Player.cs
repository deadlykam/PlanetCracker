﻿using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Others;
using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public class Player : BaseCharacter
    {
        [Header("Player Global Properties")]
        [SerializeField] private PlayerInfo _playerInfo;
        [SerializeField] private Vector3Func0 _playerPosition;
        [SerializeField] private IntVariableChange2 _playerHealth;

        protected override void Awake()
        {
            base.Awake();
            _playerPosition.SetDelegate(GetPosition);
            SetValues(_playerInfo.GetHealth(), 
                      _playerInfo.GetDamage(), 
                      _playerInfo.GetSpeed());
            _playerHealth.SetValues(_playerInfo.GetHealth(), _playerInfo.GetHealth());
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetMouseButton(0) && !IsDead()) FireWeapon(); // Firing weapon
        }

        public override void Heal(int amount)
        {
            base.Heal(amount);
            _playerHealth.SetValues(health.GetCurrentHealth(), health.GetMaxHealth());
        }

        public override void Hurt(int amount)
        {
            base.Hurt(amount);
            _playerHealth.SetValues(health.GetCurrentHealth(), health.GetMaxHealth());
        }
    }
}