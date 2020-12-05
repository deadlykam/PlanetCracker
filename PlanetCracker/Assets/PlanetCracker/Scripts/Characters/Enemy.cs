using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;

namespace PlanetCracker.Characters
{
    [RequireComponent(typeof(MoveEnemy), typeof(RotateEnemy))]
    public class Enemy : BaseCharacter
    {
        [SerializeField] private EnemyManagerHelper _enemyManager;

        protected override void Update()
        {
            base.Update();
            FireWeapon();
        }

        protected override void Dead()
        {
            base.Dead();
            _enemyManager.EnemyDied();
        }
    }
}