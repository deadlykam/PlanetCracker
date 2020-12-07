using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Managers
{
    public class StageStateManager : StateMachine
    {
        [SerializeField] private StageStateManagerHelper _helper;

        public const string WaitFadeOut = "waitFadeOut";
        public const string WaitDialog = "waitDialog";
        public const string HideDialog = "hideDialog";
        public const string EnemyGeneration = "enemyGeneration";
        public const string CheckStageDone = "checkStageDone";
        public const string ShowInteractive = "showInteractive";
        public const string WaitPressE = "waitPressE";
        public const string CenterPlayer = "centerPlayer";
        public const string HideInteractive = "hideInteractive";
        public const string ZoomOut = "zoomOut";
        public const string WaitZoomOut = "waitZoomOut";
        public const string ShowAxe = "showAxe";
        public const string WaitShowAxe = "waitShowAxe";
        public const string SwingAxe = "swingAxe";
        public const string WaitSwingAxe = "waitSwingAxe";
        public const string ShakeCamera = "shakeCamera";
        public const string ShatteredPlanet = "shatteredPlanet";
        public const string ShowUpgrade = "showUpgrade";
        public const string UpgradeSelected = "upgradeSelected";
        public const string FadeIn = "fadeIn";
        public const string WaitFadeIn = "waitFadeIn";
        public const string ChangeScene = "changeScene";

        private Dictionary<string, State> _states; // For storing all the states
        private bool _isSetupState; // Flag to check if the states have been setup

        protected virtual void Awake()
        {
            _helper.SetManager(this);
            _states = new Dictionary<string, State>();
            _isSetupState = false;
        }

        private void OnDisable() => _helper.RemoveManager();

        protected override void Update()
        {
            base.Update();
            if (!_isSetupState) SetupStates(); // Setting up states
        }

        private void SetupStates()
        {
            _states[WaitFadeOut].SetNextState(_states[WaitDialog]);
            _states[WaitDialog].SetNextState(_states[HideDialog]);
            _states[HideDialog].SetNextState(_states[EnemyGeneration]);
            _states[EnemyGeneration].SetNextState(_states[CheckStageDone]);
            _states[CheckStageDone].SetNextState(_states[ShowInteractive]);
            _states[ShowInteractive].SetNextState(_states[WaitPressE]);
            _states[WaitPressE].SetNextState(_states[CenterPlayer]);
            _states[CenterPlayer].SetNextState(_states[HideInteractive]);
            _states[HideInteractive].SetNextState(_states[ZoomOut]);
            _states[ZoomOut].SetNextState(_states[WaitZoomOut]);
            _states[WaitZoomOut].SetNextState(_states[ShowAxe]);
            _states[ShowAxe].SetNextState(_states[WaitShowAxe]);
            _states[WaitShowAxe].SetNextState(_states[SwingAxe]);
            _states[SwingAxe].SetNextState(_states[WaitSwingAxe]);
            _states[WaitSwingAxe].SetNextState(_states[ShakeCamera]);
            _states[ShakeCamera].SetNextState(_states[ShatteredPlanet]);
            _states[ShatteredPlanet].SetNextState(_states[ShowUpgrade]);
            _states[ShowUpgrade].SetNextState(_states[UpgradeSelected]);
            _states[UpgradeSelected].SetNextState(_states[FadeIn]);
            _states[FadeIn].SetNextState(_states[WaitFadeIn]);
            _states[WaitFadeIn].SetNextState(_states[ChangeScene]);

            currentState = _states[WaitFadeOut]; // Starting state
            _isSetupState = true;
        }

        /// <summary>
        /// This method adds a state.
        /// </summary>
        /// <param name="key">The key of the state, of type string</param>
        /// <param name="state">The state to add, of type StageState</param>
        public void AddState(string key, ref State state) => _states.Add(key, state);
    }
}