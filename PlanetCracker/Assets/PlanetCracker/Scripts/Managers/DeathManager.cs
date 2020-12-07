using PlanetCracker.ScriptableObjects.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Managers
{
    public class DeathManager : MonoBehaviour
    {
        [SerializeField] private DeathManagerHelper _helper;
        [SerializeField] private Transform _explosionHolder;

        private GameObject[] _explosions;
        private Queue<Vector3> _explosionRequest;
        private int _index = 0;

        private void Awake()
        {
            _helper.SetManager(this);
            _explosionRequest = new Queue<Vector3>();
            _explosions = new GameObject[_explosionHolder.childCount];

            for (_index = 0; _index < _explosionHolder.childCount; _index++)
                _explosions[_index] = _explosionHolder.GetChild(_index).gameObject;
        }

        private void OnDisable() => _helper.RemoveManager();

        private void Update()
        {
            if(_explosionRequest.Count != 0)
            {
                _index = _index + 1 >= _explosions.Length ? 0 : _index + 1;
                _explosions[_index].transform.position = _explosionRequest.Dequeue();
                _explosions[_index].SetActive(true);
            }
        }

        public void RequestExplosion(Vector3 position) 
            => _explosionRequest.Enqueue(position);
    }
}