using UnityEngine;
using UnityEngine.UI;
using ProfessionalThief.Core;
using TMPro;

namespace ProfessionalThief.UI
{
    public class LevelCompletedUI : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TextMeshProUGUI totalTake;

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

        public void SetTotalTake(float amount){
            totalTake.text = "Score $ " + amount;
        }
    }
}
