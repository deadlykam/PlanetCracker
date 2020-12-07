using PlanetCracker.Managers;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "MusicManagerHelper",
                     menuName = "PlanetCracker/ScriptableObject/Managers/" +
                                "MusicManagerHelper",
                     order = 1)]
    public class MusicManagerHelper : BaseManagerHelper<MusicManager>
    {
        public void PlayMainMenuMusic() => manager?.PlayMainMenuMusic();
        public void PlayGameplayMusic() => manager?.PlayGameplayMusic();
        public bool IsNull() => manager == null;
        public override void RemoveManager() => manager = null;
    }
}