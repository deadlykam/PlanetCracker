using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.Movements.NormalMovements
{
    public class MoveForward : MonoBehaviour, IMove
    {
        [SerializeField] private FloatVariable _simulationSpeed;

        protected float fps => Time.deltaTime * _simulationSpeed.GetValue();

        public virtual void Move(Transform target, float speed)
            => target.Translate(Vector3.forward * speed * fps);
    }
}