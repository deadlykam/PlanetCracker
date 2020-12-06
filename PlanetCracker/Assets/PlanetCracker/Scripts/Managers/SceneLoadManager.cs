using PlanetCracker.ScriptableObjects.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlanetCracker.Managers
{
    public class SceneLoadManager : MonoBehaviour
    {
        public enum SceneType { None, MainMenu, Credit, Stage1, Stage2, Stage3 };

        [SerializeField] private SceneLoadManagerHelper _helper;
        [SerializeField] private SceneType _stage;

        private string _mainMenu = "MainMenu";
        private string _credit = "Credit";
        private string _stage1 = "Stage1";
        private string _stage2 = "Stage2";
        private string _stage3 = "Stage3";

        private void Awake() => _helper.SetManager(this);
        private void OnDisable() => _helper.RemoveManager();

        private string StageTypeToName()
        {
            switch (_stage)
            {
                case SceneType.MainMenu:
                    return _mainMenu;
                case SceneType.Credit:
                    return _credit;
                case SceneType.Stage1:
                    return _stage1;
                case SceneType.Stage2:
                    return _stage2;
                case SceneType.Stage3:
                    return _stage3;
                default:
                    return "error";
            }
        }

        public void LoadStage() 
            => SceneManager.LoadScene(StageTypeToName(), LoadSceneMode.Single);
    }
}