using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.Rotations
{
    public class RotateEnemy : MonoBehaviour, IRotate
    {
        [SerializeField] private FloatVariable _simulationSpeed;
        [SerializeField] private Vector3Func0 _playerPosition;

        private Vector3 _dir;
        private Quaternion _rotation;

        protected float fps => Time.deltaTime * _simulationSpeed.GetValue();

        public void Rotate(Transform target, float speed)
        {
            _dir = _playerPosition.GetValue() - transform.position;
            _rotation = Quaternion.LookRotation(_dir);

            // Checking if rotation is NOT done
            if (_rotation != target.rotation)
                target.rotation = Quaternion.RotateTowards(target.rotation,
                                                           _rotation,
                                                           speed * fps);
        }
    }
}