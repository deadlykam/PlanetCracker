using PlanetCracker.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Rotations
{
    public class RotatePlayer : MonoBehaviour, IRotate
    {
        [SerializeField] private FloatVariable _simulationSpeed;

        protected float fps => Time.deltaTime * _simulationSpeed.GetValue();

        public void Rotate(Transform target, float speed)
        {
            if (Input.GetKey(KeyCode.A)) target.Rotate(Vector3.up * -speed * fps);
            else if (Input.GetKey(KeyCode.D)) target.Rotate(Vector3.up * speed * fps);
        }
    }
}