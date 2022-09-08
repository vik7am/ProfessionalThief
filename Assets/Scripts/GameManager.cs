using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProfessionalThief{
public class GameManager : MonoBehaviour
{
    static GameManager instance;
    bool gameOver;
    [SerializeField] GameObject sunlight;
    [SerializeField] PlayerController player;
    [SerializeField] GadgetController gadget;
    int totalLevel;

    public static GameManager Instance(){
        return instance;
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start(){
        totalLevel = System.Enum.GetNames(typeof(LevelName)).Length;
    }

    public void GameOver(){
        StopGame();
        UIManager.Instance().ShowGameoverUI();
    }

    void StopGame(){
        gameOver = true;
        player.DisablePlayer();
        sunlight.SetActive(true);
    }

    public bool IsGameOver(){
        return gameOver;
    }

    public void UnlockGadget(GadgetType gadgetType){
        gadget.UnlockGadget(gadgetType);
    }

    public void LevelCompleted(){
        StopGame();
        PlayerPrefs.SetInt("ACTIVE_LEVEL", GetNextLevelIndex());
        UIManager.Instance().ShowLevelCompletedUI();
    }

    public int GetNextLevelIndex(){
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentLevelIndex + 1 < totalLevel)
            return currentLevelIndex + 1;
        else
            return 0;
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(GetNextLevelIndex());
    }
}
}
