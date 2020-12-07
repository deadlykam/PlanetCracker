using UnityEngine;
using PlanetCracker.NormalizedValues;
using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using PlanetCracker.Managers;

namespace PlanetCracker.Cameras
{
    [RequireComponent(typeof(AccelerateValue))]
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] StageStateManagerHelper _stageStateManager;
        [SerializeField] private float _minZoom;
        [SerializeField] private float _maxZoom;

        private Camera _camera;
        private AccelerateValue _accelerate;
        private bool _isZoomOut;

        private State _zoomOut;
        private State _waitZoomOut;

        private void Awake()
        {
            _camera = Camera.main;
            _accelerate = GetComponent<AccelerateValue>();
        }

        private void Start()
        {
            _zoomOut = new CallOnceState(_stageStateManager.GetManager(),
                                     StageStateManager.ZoomOut,
                                     StartZoomOut);

            _waitZoomOut = new FlagCheckState(_stageStateManager.GetManager(), 
                                              StageStateManager.WaitZoomOut, 
                                              IsZoomingOut, false);

            _stageStateManager.AddState(StageStateManager.ZoomOut, ref _zoomOut);
            _stageStateManager.AddState(StageStateManager.WaitZoomOut, ref _waitZoomOut);
        }

        private void Update()
        {
            if (IsZoomingOut())
            {
                _accelerate.Accelerate();
                _camera.orthographicSize = Mathf.Lerp(_minZoom, _maxZoom,
                                                      _accelerate.GetNormalValue());
            }
        }

        private void StartZoomOut() => _isZoomOut = true;
        private bool IsZoomingOut() => _isZoomOut && _accelerate.GetNormalValue() != 1f;
    }
}