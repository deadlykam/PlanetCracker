using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.NormalizedValues
{
    public interface INormalValue
    {
        /// <summary>
        /// This method accelerates the normal value.
        /// </summary>
        void Accelerate();

        /// <summary>
        /// This method decelerates the normal value.
        /// </summary>
        void Decelerate();

        void SetNormalValue(float value);

        /// <summary>
        /// This method gets the normal value.
        /// </summary>
        /// <returns>The normal value to get, of type float</returns>
        float GetNormalValue();
    }
}