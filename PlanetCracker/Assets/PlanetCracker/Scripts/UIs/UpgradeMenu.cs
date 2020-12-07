using PlanetCracker.Managers;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.ScriptableObjects.Others;
using PlanetCracker.States;
using TMPro;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public class UpgradeMenu : BaseCanvasMenu
    {
        [SerializeField] private StageStateManagerHelper _stageStageManager;
        [SerializeField] private PlayerInfo _playerInfo;
        [SerializeField] private int _health;
        [SerializeField] private int _dmg;
        [SerializeField] private int _speed;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private TextMeshProUGUI _speedText;

        private State _showUpgrade;
        private State _upgradeSelected;
        private bool _isUpgraded = false;

        private string _healthMsg => $"Increase overall health by {_health.ToString()}.";
        private string _damageMsg => $"Increase overall damage by {_dmg.ToString()}.";
        private string _speedMsg => $"Increase speed and turn speed by {_speed.ToString()}.";

        private void Start()
        {
            _showUpgrade = new CallOnceState(_stageStageManager.GetManager(), 
                                             StageStateManager.ShowUpgrade, ShowMenu);

            _upgradeSelected = new FlagCheckState(_stageStageManager.GetManager(),
                                                  StageStateManager.UpgradeSelected,
                                                  IsUpgradeSelected, true);

            _stageStageManager.AddState(StageStateManager.ShowUpgrade, ref _showUpgrade);
            _stageStageManager.AddState(StageStateManager.UpgradeSelected, ref _upgradeSelected);

            _healthText.text = _healthMsg;
            _damageText.text = _damageMsg;
            _speedText.text = _speedMsg;
        }

        private bool IsUpgradeSelected() => _isUpgraded;

        public void BtnHP()
        {
            _playerInfo.IncreaseHealth(_health);
            _isUpgraded = true;
            HideMenu();
        }

        public void BtnDmg()
        {
            _playerInfo.IncreaseDamage(_dmg);
            _isUpgraded = true;
            HideMenu();
        }

        public void BtnSpd()
        {
            _playerInfo.IncreaseSpeed(_speed);
            _isUpgraded = true;
            HideMenu();
        }
    }
}