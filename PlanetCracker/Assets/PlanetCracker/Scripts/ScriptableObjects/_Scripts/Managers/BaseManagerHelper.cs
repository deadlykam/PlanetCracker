using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    public abstract class BaseManagerHelper<T> : ScriptableObject
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

        /// <summary>
        /// This method removes the stored manager.
        /// </summary>
        public abstract void RemoveManager();
    }
}