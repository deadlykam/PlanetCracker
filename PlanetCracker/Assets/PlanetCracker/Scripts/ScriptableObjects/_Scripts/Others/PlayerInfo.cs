using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Others
{
    [CreateAssetMenu(fileName = "PlayerInfo",
                     menuName = "PlanetCracker/ScriptableObject/Others/" +
                                "PlayerInfo",
                     order = 1)]
    public class PlayerInfo : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private int _defaultHealth;
        [SerializeField] private int _defaultDamage;
        [SerializeField] private float _defaultSpeed;

        public void IncreaseHealth(int amount) => _health += amount;
        public void IncreaseDamage(int amount) => _damage += amount;
        public void IncreaseSpeed(int amount) => _speed += amount;
        public int GetHealth() => _health;
        public int GetDamage() => _damage;
        public float GetSpeed() => _speed;

        public void ResetValue()
        {
            _health = _defaultHealth;
            _damage = _defaultDamage;
            _speed = _defaultSpeed;
        }
    }
}