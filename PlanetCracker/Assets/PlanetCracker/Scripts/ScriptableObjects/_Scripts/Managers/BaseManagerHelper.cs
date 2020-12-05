using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    public class BaseManagerHelper<T> : ScriptableObject
    {
        protected T manager; // The manager reference

        /// <summary>
        /// This method gets the manager.
        /// </summary>
        /// <returns>The manager, of type T</returns>
        public T GetManager() => manager;

        /// <summary>
        /// This method sets the manager.
        /// </summary>
        /// <param name="manager">The manager to set, of type T</param>
        public void SetManager(T manager) => this.manager = manager;
    }
}