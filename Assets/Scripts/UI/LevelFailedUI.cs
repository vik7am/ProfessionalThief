using UnityEngine;
using UnityEngine.UI;
using ProfessionalThief.Core;

namespace ProfessionalThief.UI
{
    public class LevelFailedUI : MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button exitButton;

        private void Start(){
            restartLevelButton.onClick.AddListener(RestartCurrentLevel);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void RestartCurrentLevel(){
            GameManager.Instance.ResumeGame();
            LevelManager.Instance.ReloadCurrentLevel();
        }

        private void ExitGame(){
            GameManager.Instance.ResumeGame();
            LevelManager.Instance.LoadMainMenu();
        }
    }
}
