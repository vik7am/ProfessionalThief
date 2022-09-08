using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ProfessionalThief{
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button exitButton;
    int activeLevel;

    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(StartNewGame);
        exitButton.onClick.AddListener(ExitGame);
        GetActiveLevel();
    }

    void GetActiveLevel(){
        activeLevel = PlayerPrefs.GetInt("ACTIVE_LEVEL", (int)LevelName.MAIN_MENU);
        if(activeLevel == 0)
            continueButton.gameObject.SetActive(false);
    }

    void ContinueGame()
    {
        SceneManager.LoadScene(activeLevel);
    }

    void StartNewGame()
    {
        SceneManager.LoadScene((int)LevelName.LEVEL1);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
}
