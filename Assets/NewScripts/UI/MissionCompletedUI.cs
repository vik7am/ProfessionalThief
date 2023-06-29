using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace ProfessionalThief.UI
{
    public class MissionCompletedUI : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button exitButton;

        private void Start(){
            nextLevelButton.onClick.AddListener(LoadNextLevel);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void LoadNextLevel(){
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = (currentScene + 1) % sceneCount;
            Time.timeScale = 1;
            SceneManager.LoadScene(nextScene);
        }

        private void ExitGame(){
            Application.Quit();
        }
    }
}
