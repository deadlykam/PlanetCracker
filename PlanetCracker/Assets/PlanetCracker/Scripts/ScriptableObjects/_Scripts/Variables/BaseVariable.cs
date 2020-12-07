using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Variables
{
    public abstract class BaseVariable<T> : ScriptableObject
    {
        [SerializeField] private bool _isDebug;
        protected T value; //  Storing the value

        /// <summary>
        /// Getting the value of the variable.
        /// </summary>
        /// <returns>The variable value, of type T</returns>
        public virtual T GetValue()
        {
            if (_isDebug)
                Debug.Log($"{name} -> Get Value: " +
                    $"{(IsValueNull() ? GetDefaultValue().ToString() : value.ToString())}");

            if (IsValueNull()) return GetDefaultValue(); // Sending default value
            return value; // Sending value
        }

        /// <summary>
        /// This method sets the value of the variable.
        /// </summary>
        /// <param name="value">The value to set, of type T generic</param>
        public virtual void SetValue(T value)
        {
            if (_isDebug) Debug.Log($"{name} -> Set Value: {value.ToString()}");
            this.value = value;
        }

        /// <summary>
        /// The default value of the variable.
        /// </summary>
        /// <returns>The default value, of type T</returns>
        protected abstract T GetDefaultValue();

        /// <summary>
        /// This method checks if the value is null.
        /// </summary>
        /// <returns>True means null, false otherwise, of type bool</returns>
        protected abstract bool IsValueNull();

        /// <summary>
        /// This method resets the script to default.
        /// </summary>
        public abstract void ResetScript();

        public override string ToString() => $"{base.ToString()}: {value.ToString()}";
    }
}