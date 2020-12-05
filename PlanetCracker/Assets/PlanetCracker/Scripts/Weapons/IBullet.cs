using UnityEngine;

namespace PlanetCracker.Weapons
{
    public interface IBullet
    {
        /// <summary>
        /// This method sets up the bullet during initialization.
        /// </summary>
        /// <param name="weapon">The main weapon for the bullet, of type IWeapon</param>
        void SetupBullet(IWeapon weapon);

        /// <summary>
        /// This method fires teh bullet.
        /// </summary>
        /// <param name="position">The position of the bullet to place at start,
        ///                        of type Vector3</param>
        /// <param name="rotation">The rotation of the bullet, of type Quaternion</param>
        void FireBullet(Vector3 position, Quaternion rotation);

        /// <summary>
        /// This method kills the bullet.
        /// </summary>
        void KillBullet();
    }
}