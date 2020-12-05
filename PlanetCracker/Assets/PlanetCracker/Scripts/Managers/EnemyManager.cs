using PlanetCracker.Characters;
using PlanetCracker.ScriptableObjects.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyManagerHelper _helper;
    [SerializeField] private Transform _enemyHolder;
    [SerializeField] private Transform _genPointHolder;
    [SerializeField] private int _genThreshold; // The threshold after to generate enemies
    [SerializeField] private int _maxEnemies; // Max amount of enemy to generate

    private Queue<Enemy> _enemies;
    private int _index;
    private int _enemyGenCounter;
    private bool _isGenEnemy;

    private void Awake()
    {
        _helper.SetManager(this);
        _enemies = new Queue<Enemy>();

        // Loop for adding all the enemies
        for (_index = 0; _index < _enemyHolder.childCount; _index++)
            _enemies.Enqueue(_enemyHolder.GetChild(_index).GetComponent<Enemy>());
    }

    private void Update()
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
        else Debug.Log("Stage Completed!");
    }

    /// <summary>
    /// This method checks if the stage is complete.
    /// </summary>
    /// <returns>True means stage is completed, false otherwise, of type bool</returns>
    private bool IsStageCompleted() => _enemies.Count == 0 && _enemyGenCounter == 0;

    /// <summary>
    /// This method counts when an enemy has died.
    /// </summary>
    public void EnemyDied() => _enemyGenCounter--;
}
