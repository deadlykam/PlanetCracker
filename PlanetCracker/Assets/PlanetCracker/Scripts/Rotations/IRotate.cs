using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Rotations
{
    public interface IRotate
    {
        /// <summary>
        /// Rotating the object towards the direction.
        /// </summary>
        /// <param name="target">The object to rotate, of type Transform</param>
        /// <param name="speed">The speed of rotation, of type float</param>
        void Rotate(Transform target, float speed);
    }
}