using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.Rotations;
using UnityEngine;

namespace PlanetCracker.Characters
{
    [RequireComponent(typeof(MoveEnemy), typeof(RotateEnemy))]
    public class Enemy : BaseCharacter
    {
        protected override void Update()
        {
            base.Update();
            FireWeapon();
        }
    }
}