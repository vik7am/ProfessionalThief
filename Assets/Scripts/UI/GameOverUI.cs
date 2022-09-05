using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ProfessionalThief{
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
        SceneManager.LoadScene(0);
    }

    void QuitGame(){
        Application.Quit();
    }
}
}
