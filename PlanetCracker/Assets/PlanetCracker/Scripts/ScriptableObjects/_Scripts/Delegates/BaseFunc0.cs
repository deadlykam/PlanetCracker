using System;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Delegates
{
    public abstract class BaseFunc0<T> : ScriptableObject
    {
        protected Func<T> returner; // The return type delegate to call

        /// <summary>
        /// This method checks if the delegate has been setup.
        /// </summary>
        /// <returns>True means the delegate has been setup, false otherwise,
        ///          of type bool</returns>
        protected bool HasReturner() => !Delegate.Equals(returner, null);

        /// <summary>
        /// This method gets the value from the delegate.
        /// </summary>
        /// <returns>The value T from the delegate, of type 
        ///          <typeparamref name="T"/></returns>
        public virtual T GetValue() => returner();

        /// <summary>
        /// This method sets the delegate.
        /// </summary>
        /// <param name="returner">The delegate to set, of type 
        ///                        Func<<typeparamref name="T"/>></param>
        public virtual void SetDelegate(Func<T> returner)
            => this.returner = returner;

        /// <summary>
        /// This method resets the script to default.
        /// </summary>
        public abstract void ResetScript();
    }
}