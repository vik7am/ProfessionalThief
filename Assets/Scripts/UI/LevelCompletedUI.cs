using UnityEngine;
using UnityEngine.UI;
using ProfessionalThief.Core;


namespace ProfessionalThief.UI
{
    public class LevelCompletedUI : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button exitButton;

        private void Start(){
            nextLevelButton.onClick.AddListener(LoadNextLevel);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void LoadNextLevel(){
            GameManager.Instance.ResumeGame();
            LevelManager.Instance.LoadNextLevel();
        }

        private void ExitGame(){
            GameManager.Instance.ResumeGame();
            LevelManager.Instance.LoadMainMenu();
        }
    }
}
