using PlanetCracker.ScriptableObjects.Delegates;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public class Player : BaseCharacter
    {
        [Header("Player Global Properties")]
        [SerializeField] private Vector3Func0 _playerPosition;

        protected override void Awake()
        {
            base.Awake();
            _playerPosition.SetDelegate(GetPosition);
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetMouseButton(0)) FireWeapon(); // Firing weapon
        }
    }
}