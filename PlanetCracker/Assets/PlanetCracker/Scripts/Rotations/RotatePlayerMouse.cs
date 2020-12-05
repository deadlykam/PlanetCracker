using PlanetCracker.ScriptableObjects.Variables;
using UnityEngine;

namespace PlanetCracker.Rotations
{
    public class RotatePlayerMouse : MonoBehaviour, IRotate
    {
        [SerializeField] private FloatVariable _simulationSpeed;

        private Camera _camera;
        private Ray _ray;
        private RaycastHit[] _hits;
        private int _hitIndex;
        private Vector3 _dir;
        private Quaternion _rotation;

        protected float fps => Time.deltaTime * _simulationSpeed.GetValue();

        private void Start() => _camera = Camera.main;

        /// <summary>
        /// This method calculates the mouse position.
        /// </summary>
        private void CalculateMousePosition()
        {
            // Casting ray from the camera
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            _hits = Physics.RaycastAll(_ray); // Recording all hits

            if(_hits.Length != 0) // Checking any hits
            {
                // Loop for finding the correct hit
                for(_hitIndex = 0; _hitIndex < _hits.Length; _hitIndex++)
                {
                    // Finding the mouse area hit
                    if(_hits[_hitIndex].transform.gameObject.layer == 
                        LayerMask.NameToLayer("MouseArea"))
                        _dir = _hits[_hitIndex].point - transform.position;
                }
            }
        }

        public void Rotate(Transform target, float speed)
        {
            CalculateMousePosition(); // Calculating the mouse position

            // Calcualting the rotation direction
            _rotation = Quaternion.LookRotation(_dir);

            // Checking if rotation is NOT done
            if (_rotation != target.rotation)
                target.rotation = Quaternion.RotateTowards(target.rotation,
                                                           _rotation,
                                                           speed * fps);
        }
    }
}