using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.UI
{
    public enum UI_ID {MAIN_MENU, HUD, LEVEL_COMPLETED, LEVEL_FAILED}

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private MainMenuUI mainMenuUI;
        [SerializeField] private HUDUI hudUI;
        [SerializeField] private LevelCompletedUI levelCompletedUI;
        [SerializeField] private LevelFailedUI levelFailedUI;
        private GameObject activeUI;

        private void Start(){
            if(LevelManager.Instance.CurrentLevelIndex == 0){
                SwitchUI(UI_ID.MAIN_MENU);
                return;
            }
            SwitchUI(UI_ID.HUD);
        }

        private void OnEnable() {
            GameManager.onGameOver += OnGameOver;
            GameManager.onLevelCompleted += OnLevelCompleted;
        }

        private void OnDisable() {
            GameManager.onGameOver -= OnGameOver;
            GameManager.onLevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelCompleted(int totalItemValue){
            GameManager.Instance.PauseGame();
            SwitchUI(UI_ID.LEVEL_COMPLETED);
            levelCompletedUI.SetTotalItemValue(totalItemValue);
        }

        private void OnGameOver(string detectorName){
            GameManager.Instance.PauseGame();
            SwitchUI(UI_ID.LEVEL_FAILED);
            levelFailedUI.SetLevelFailedReason(detectorName);
        }

        public void SwitchUI(UI_ID userInterfaceID){
            if(activeUI != null)
                activeUI.SetActive(false);
            switch(userInterfaceID){
                case UI_ID.MAIN_MENU : activeUI = mainMenuUI.gameObject; break;
                case UI_ID.HUD : activeUI = hudUI.gameObject; break;
                case UI_ID.LEVEL_COMPLETED : activeUI = levelCompletedUI.gameObject; break;
                case UI_ID.LEVEL_FAILED : activeUI = levelFailedUI.gameObject; break;
            }
            activeUI.SetActive(true);
        }
    }
}
