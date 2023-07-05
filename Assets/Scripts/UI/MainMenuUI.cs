using ProfessionalThief.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProfessionalThief.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button exitButton;
    
        private void Start(){
            newGameButton.onClick.AddListener(StartNewGame);
            exitButton.onClick.AddListener(ExitGame);
        }
    
        private void StartNewGame(){
            LevelManager.Instance.LoadNextLevel();
        }
    
        private void ExitGame(){
            Application.Quit();
        }
    }
}
