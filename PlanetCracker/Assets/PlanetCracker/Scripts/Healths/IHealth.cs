using UnityEngine;

namespace PlanetCracker.Healths
{
    public interface IHealth
    {
        /// <summary>
        /// All the setups needed during start up.
        /// </summary>
        /// <param name="maxHealth">The maximum health of the object, of type int</param>
        void StartSetup(int maxHealth);

        /// <summary>
        /// This method heals the object.
        /// </summary>
        /// <param name="amount">The amount to heal by, of type int</param>
        void Heal(int amount);

        /// <summary>
        /// This method hurts the object.
        /// </summary>
        /// <param name="amount">The amount to hurt by, of type int</param>
        void Hurt(int amount);

        /// <summary>
        /// This method gets the max health.
        /// </summary>
        /// <returns>The max health, of type int</returns>
        int GetMaxHealth();

        /// <summary>
        /// This method gets the current health.
        /// </summary>
        /// <returns>The current health, of type int</returns>
        int GetCurrentHealth();

        /// <summary>
        /// This method checks if the object is dead.
        /// </summary>
        /// <returns>Flag to check if the object is dead, of type bool</returns>
        bool IsDead();

        /// <summary>
        /// This method resets the health back to default.
        /// </summary>
        void Restore();
    }
}