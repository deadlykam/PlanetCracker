namespace PlanetCracker.Weapons
{
    public interface IWeapon
    {
        /// <summary>
        /// This method fires the weapon.
        /// </summary>
        void Fire();
        
        /// <summary>
        /// This method sets the damage for the weapon.
        /// </summary>
        /// <param name="damage">The damage to set, of type int</param>
        void SetBulletDamage(int damage);

        /// <summary>
        /// The damage of the bullet.
        /// </summary>
        /// <returns>The damage of the bullet, of type int</returns>
        int GetBulletDamage();

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
