using PlanetCracker.Characters;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Managers {
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyManagerHelper _helper;
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private Transform _enemyHolder;
        [SerializeField] private Transform _genPointHolder;
        [SerializeField] private int _genThreshold; // The threshold after to generate enemies
        [SerializeField] private int _maxEnemies; // Max amount of enemy to generate

        private Queue<Enemy> _enemies;
        private int _index;
        private int _enemyGenCounter;
        private bool _isGenEnemy;
        private bool _isStartManager = false;

        private State _checkStageDone;
        private State _enemyGeneration;

        private void Awake()
        {
            _helper.SetManager(this);
            _enemies = new Queue<Enemy>();

            // Loop for adding all the enemies
            for (_index = 0; _index < _enemyHolder.childCount; _index++)
                _enemies.Enqueue(_enemyHolder.GetChild(_index).GetComponent<Enemy>());
        }

        private void OnDisable() => _helper.RemoveManager();

        private void Start()
        {
            _checkStageDone = new FlagCheckState(_stageStateManager.GetManager(),
                                                 StageStateManager.CheckStageDone,
                                                 IsStageCompleted, true);

            _enemyGeneration = new CallOnceState(_stageStateManager.GetManager(), 
                                                 StageStateManager.EnemyGeneration, 
                                                 StartManager);

            _stageStateManager.AddState(StageStateManager.CheckStageDone,
                                        ref _checkStageDone);

            _stageStateManager.AddState(StageStateManager.EnemyGeneration,
                                        ref _enemyGeneration);
        }

        private void Update()
        {
            if (_isStartManager) GenerateEnemies();
        }

        private void GenerateEnemies()
        {
            if (!IsStageCompleted()) // Condition for generating enemy
            {
                // Condition for starting to generate enemy
                if (_enemyGenCounter <= _genThreshold && _enemies.Count != 0) _isGenEnemy = true;

                if (_isGenEnemy && _enemies.Count != 0) // Generating enemy
                {
                    if (_enemyGenCounter < _maxEnemies) // Checking if enemy can generate
                    {
                        _index = _index + 1 >= _genPointHolder.childCount ? 0 : _index + 1;
                        _enemies.Dequeue()
                            .StartCharacter(_genPointHolder.GetChild(_index).position);
                        _enemyGenCounter++;
                    }
                    else _isGenEnemy = false; // No more generation
                }
            }
        }

        /// <summary>
        /// This method checks if the stage is complete.
        /// </summary>
        /// <returns>True means stage is completed, false otherwise, of type bool</returns>
        private bool IsStageCompleted() => _enemies.Count == 0 && _enemyGenCounter == 0;

        private void StartManager() => _isStartManager = true;

        /// <summary>
        /// This method counts when an enemy has died.
        /// </summary>
        public void EnemyDied() => _enemyGenCounter--;
    }
}