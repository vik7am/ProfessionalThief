using UnityEngine;
using UnityEngine.UI;

namespace ProfessionalThief.V1{
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button exitButton;
    LevelName activeLevel;

    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(StartNewGame);
        exitButton.onClick.AddListener(ExitGame);
        GetActiveLevel();
    }

    void GetActiveLevel(){
        activeLevel = (LevelName)PlayerPrefs.GetInt("ACTIVE_LEVEL", (int)LevelName.MAIN_MENU);
        if(activeLevel == LevelName.MAIN_MENU)
            continueButton.gameObject.SetActive(false);
    }

    void ContinueGame(){
        Utils.LoadLevel(activeLevel);
    }

    void StartNewGame(){
        Utils.LoadLevel(LevelName.LEVEL1);
    }

    void ExitGame(){
        Application.Quit();
    }
}
}
