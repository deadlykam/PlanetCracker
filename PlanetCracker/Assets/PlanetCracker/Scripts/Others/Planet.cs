using PlanetCracker.Managers;
using PlanetCracker.ScriptableObjects.Delegates;
using PlanetCracker.ScriptableObjects.Managers;
using PlanetCracker.States;
using UnityEngine;

namespace PlanetCracker.Others
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private StageStateManagerHelper _stageStateManager;
        [SerializeField] private GameObject _planet;
        [SerializeField] private GameObject _planetShattered;
        [SerializeField] private GameObject _explosion;

        private State _shatteredPlanet;

        private void Start()
        {
            _shatteredPlanet = new CallOnceState(_stageStateManager.GetManager(), 
                                                 StageStateManager.ShatteredPlanet, 
                                                 ShowShattered);

            _stageStateManager.AddState(StageStateManager.ShatteredPlanet, 
                                        ref _shatteredPlanet);
        }

        private void ShowShattered()
        {
            _planet.SetActive(false);
            _planetShattered.SetActive(true);
            _explosion.SetActive(true);
        }
    }
}