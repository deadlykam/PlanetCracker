using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.Movements.NormalMovements
{
    public interface IMove
    {
        /// <summary>
        /// This method moves the object forward.
        /// </summary>
        /// <param name="target">The object to move forward, of type Transform</param>
        /// <param name="speed">The speed of the object movement, of type float</param>
        void Move(Transform target, float speed);

        bool IsMoving();
    }
}