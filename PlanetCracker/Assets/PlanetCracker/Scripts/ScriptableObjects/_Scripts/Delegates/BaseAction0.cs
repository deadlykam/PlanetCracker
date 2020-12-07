using System;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Delegates
{
    public class BaseAction0 : ScriptableObject
    {
        protected Action action; // The action delegate to call

        /// <summary>
        /// This method checks if the delegate has been setup.
        /// </summary>
        /// <returns>True means the delegate has been setup, false otherwise,
        ///          of type bool</returns>
        protected bool HasAction() => !Delegate.Equals(action, null);

        /// <summary>
        /// This method calls the delegate action.
        /// </summary>
        public virtual void CallAction()
        {
            // Checking if delegate has been set up
            if (HasAction()) action();
        }

        /// <summary>
        /// This method sets the delegate.
        /// </summary>
        /// <param name="action">The delegate to set, of type Action</param>
        public virtual void SetDelegate(Action action) => this.action = action;

        /// <summary>
        /// This method removes the delegate.
        /// </summary>
        public virtual void RemoveDelegate() => action = null;
    }
}