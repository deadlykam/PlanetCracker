using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;

namespace PlanetCracker.Managers
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private MusicManagerHelper _helper;
        [SerializeField] private AudioSource _mainMenuMusic;
        [SerializeField] private AudioSource _gameplayMusic;

        private bool _isMenuMusic = false;

        private void Awake()
        {
            if (_helper.IsNull()) DontDestroyOnLoad(gameObject);
            else Destroy(gameObject);
        }

        private void OnEnable()
        {
            if(_helper.IsNull()) _helper.SetManager(this);
        }

        public void PlayMainMenuMusic()
        {
            if (!_isMenuMusic)
            {
                _gameplayMusic.Stop();
                _mainMenuMusic.Play();
                _isMenuMusic = true;
            }
        }

        public void PlayGameplayMusic()
        {
            if (_isMenuMusic)
            {
                _mainMenuMusic.Stop();
                _gameplayMusic.Play();
                _isMenuMusic = false;
            }
        }
    }
}