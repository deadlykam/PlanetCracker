using UnityEngine;
using PlanetCracker.ScriptableObjects.Delegates;

namespace PlanetCracker.Others
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Vector3Func0 _playerPosition;

        private void Update() => transform.position = _playerPosition.GetValue();
    }
}