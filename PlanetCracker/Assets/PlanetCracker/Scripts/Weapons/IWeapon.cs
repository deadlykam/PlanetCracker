namespace PlanetCracker.Weapons
{
    public interface IWeapon
    {
        /// <summary>
        /// This method fires the weapon.
        /// </summary>
        void Fire();

        /// <summary>
        /// The damage of the bullet.
        /// </summary>
        /// <returns>The damage of the bullet, of type float</returns>
        float GetBulletDamage();

        /// <summary>
        /// The speed of the bullet.
        /// </summary>
        /// <returns>The speed of the bullet, of type float</returns>
        float GetBulletSpeed();

        /// <summary>
        /// The target tag for the bullets to hit.
        /// </summary>
        /// <returns>The target tag for the bullets to hit, of type string</returns>
        string GetTargetTag();
    }
}
