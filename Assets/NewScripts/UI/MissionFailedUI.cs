using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ProfessionalThief.UI
{
    public class MissionFailedUI : MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button exitButton;

        private void Start(){
            restartLevelButton.onClick.AddListener(RestartCurrentLevel);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void RestartCurrentLevel(){
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            Time.timeScale = 1;
            SceneManager.LoadScene(currentScene);
        }

        private void ExitGame(){
            Application.Quit();
        }
    }
}
