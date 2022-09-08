using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ProfessionalThief{
public class LevelCompletedUI : MonoBehaviour
{
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button quitButton;
    
    void Start()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    void LoadNextLevel(){
        GameManager.Instance().LoadNextLevel();
    }

    void QuitGame(){
        SceneManager.LoadScene(0);
    }
}
}