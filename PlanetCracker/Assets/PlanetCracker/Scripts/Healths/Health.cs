using UnityEngine;

namespace PlanetCracker.Healths
{
    public class Health : MonoBehaviour, IHealth
    {
        private int _maxHealth;
        private int _currentHealth;

        /// <summary>
        /// The total health of the character, of type int
        /// </summary>
        private int _totalMaxHealth => _maxHealth;

        /// <summary>
        /// Setting the health at start up.
        /// </summary>
        /// <param name="maxHealth">The maximum health of the object, of type int</param>
        public void StartSetup(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        /// <summary>
        /// This method heals the object.
        /// </summary>
        /// <param name="amount">The amount to heal by, of type int</param>
        public void Heal(int amount)
            => _currentHealth = _currentHealth + amount >= _totalMaxHealth ?
                                _totalMaxHealth :
                                _currentHealth + amount;

        /// <summary>
        /// This method hurts the object.
        /// </summary>
        /// <param name="amount">The amount to hurt by, of type int</param>
        public void Hurt(int amount)
            => _currentHealth = _currentHealth - amount <= 0 ?
                                0 :
                                _currentHealth - amount;

        /// <summary>
        /// The max health.
        /// </summary>
        /// <returns>The maximum health including extra, of type int</returns>
        public int GetMaxHealth() => _totalMaxHealth;

        /// <summary>
        /// The current health.
        /// </summary>
        /// <returns>The current health, of type int</returns>
        public int GetCurrentHealth() => _currentHealth;

        /// <summary>
        /// This method resets health back to default.
        /// </summary>
        public void Restore() => _currentHealth = _maxHealth;

        /// <summary>
        /// This method checks if the object is dead.
        /// </summary>
        /// <returns>Flag to check if the object is dead, of type bool</returns>
        public bool IsDead() => _currentHealth == 0;
    }
}