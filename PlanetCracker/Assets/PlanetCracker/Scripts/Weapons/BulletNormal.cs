using PlanetCracker.Movements.NormalMovements;
using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.Weapons
{
    [RequireComponent(typeof(MoveForward))]
    public class BulletNormal : MonoBehaviour, IBullet
    {
        [SerializeField] private TransformVariable _bulletContainer;

        private IWeapon _weapon;
        private IMove _movement;
        private string _tagEnvironment = "Environment";

        private void Update() => _movement.Move(transform, _weapon.GetBulletSpeed());

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_weapon.GetTargetTag())) Debug.Log("Character Hit!");
            else if (other.CompareTag(_tagEnvironment)) gameObject.SetActive(false);
        }

        public void SetupBullet(IWeapon weapon)
        {
            _weapon = weapon;
            _movement = GetComponent<IMove>();
        }

        public void FireBullet(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.SetParent(_bulletContainer.GetValue());
            gameObject.SetActive(true);
        }

        public void KillBullet()
        {
            throw new System.NotImplementedException();
        }
    }
}