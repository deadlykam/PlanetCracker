using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Others;
using UnityEngine;

namespace PlanetCracker.Characters
{
    public class Player : BaseCharacter
    {
        [Header("Player Global Properties")]
        [SerializeField] private PlayerInfo _playerInfo;
        [SerializeField] private Vector3Func0 _playerPosition;

        protected override void Awake()
        {
            base.Awake();
            _playerPosition.SetDelegate(GetPosition);
            SetValues(_playerInfo.GetHealth(), 
                      _playerInfo.GetDamage(), 
                      _playerInfo.GetSpeed());
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetMouseButton(0) && !IsDead()) FireWeapon(); // Firing weapon
        }
    }
}