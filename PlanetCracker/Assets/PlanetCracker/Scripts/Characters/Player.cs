using PlanetCracker.ScriptableObjects.Delegates;
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
        [SerializeField] private ActionNormal0 _deathMenuShow;
        [SerializeField] private ActionNormal0 _placeCenter;

        protected override void Awake()
        {
            base.Awake();
            _playerPosition.SetDelegate(GetPosition);
            _placeCenter.SetDelegate(PlaceCenter);
            SetValues(_playerInfo.GetHealth(), 
                      _playerInfo.GetDamage(), 
                      _playerInfo.GetSpeed());
            _playerHealth.SetValues(_playerInfo.GetHealth(), _playerInfo.GetHealth());
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _playerPosition.ResetScript();
            _placeCenter.RemoveDelegate();
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetMouseButton(0) && !IsDead()) FireWeapon(); // Firing weapon
        }

        protected override void Dead()
        {
            base.Dead();
            _deathMenuShow.CallAction();
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

        public void PlaceCenter() => transform.position = Vector3.zero;
    }
}