using PlanetCracker.Managers;
using PlanetCracker.NormalizedValues;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetCracker.UIs
{
    [RequireComponent(typeof(AccelerateValue))]
    public class FadeMenu : BaseCanvasMenu
    {
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _startFadeValue;

        private AccelerateValue _accelerate;
        private bool _isFadeIn = false;
        private Color _fadeColour;

        private State _waitFadeOut;
        private State _fadeIn;
        private State _waitFadeIn;

        private void Awake()
        {
            _accelerate = GetComponent<AccelerateValue>();
            _accelerate.SetNormalValue(_startFadeValue);
            _fadeColour = _fadeImage.color;
        }

        private void Start()
        {
            _waitFadeOut = new FlagCheckState(_stageStateManager.GetManager(),
                                          StageStateManager.WaitFadeOut, IsFadeOut, true);

            _fadeIn = new CallOnceState(_stageStateManager.GetManager(), 
                                        StageStateManager.FadeIn, StartFadeIn);

            _waitFadeIn = new FlagCheckState(_stageStateManager.GetManager(),
                                          StageStateManager.WaitFadeIn, IsFadeIn, true);

            _stageStateManager.AddState(StageStateManager.WaitFadeOut, ref _waitFadeOut);
            _stageStateManager.AddState(StageStateManager.FadeIn, ref _fadeIn);
            _stageStateManager.AddState(StageStateManager.WaitFadeIn, ref _waitFadeIn);
        }

        private void Update()
        {
            if (_isFadeIn)
            {
                if(_accelerate.GetNormalValue() != 1)
                {
                    _accelerate.Accelerate();
                    SetFadeAlpha(_accelerate.GetNormalValue());
                }
            }
            else
            {
                if (_accelerate.GetNormalValue() != 0)
                {
                    _accelerate.Decelerate();
                    SetFadeAlpha(_accelerate.GetNormalValue());
                }
            }
        }

        private void SetFadeAlpha(float alpha)
        {
            _fadeColour.a = alpha;
            _fadeImage.color = _fadeColour;
        }

        private void StartFadeIn() => _isFadeIn = true;
        private bool IsFadeIn() => _accelerate.GetNormalValue() == 1;
        private bool IsFadeOut() => _accelerate.GetNormalValue() == 0;
    }
}