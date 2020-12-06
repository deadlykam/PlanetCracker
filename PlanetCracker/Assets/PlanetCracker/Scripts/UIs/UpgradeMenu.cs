using PlanetCracker.Managers;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.ScriptableObjects.Others;
using PlanetCracker.States;
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

        private State _showUpgrade;

        private void Start()
        {
            _showUpgrade = new CallOnceState(_stageStageManager.GetManager(), 
                                             StageStateManager.ShowUpgrade, ShowMenu);

            _stageStageManager.AddState(StageStateManager.ShowUpgrade, ref _showUpgrade);
        }

        private void ChangeScene()
        {
            Debug.Log("Scene Changed");
        }
        
        public void BtnHP()
        {
            _playerInfo.IncreaseHealth(_health);
            ChangeScene();
            HideMenu();
        }

        public void BtnDmg()
        {
            _playerInfo.IncreaseDamage(_dmg);
            ChangeScene();
            HideMenu();
        }

        public void BtnSpd()
        {
            _playerInfo.IncreaseSpeed(_speed);
            ChangeScene();
            HideMenu();
        }
    }
}