using UnityEngine;
using UnityEngine.UI;

namespace ProfessionalThief.V1{
public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void RestartGame(){
        Utils.ReloadLevel();
    }

    void QuitGame(){
        Utils.LoadLevel(LevelName.MAIN_MENU);
    }
}
}
