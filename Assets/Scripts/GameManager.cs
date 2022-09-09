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
        UnlockGadgets();
    }

    void UnlockGadgets(){
        LevelName levelName = (LevelName)SceneManager.GetActiveScene().buildIndex;
        switch(levelName){
            case LevelName.LEVEL2 : gadget.UnlockGadget(GadgetType.TORCH); break;
            case LevelName.LEVEL3 : 
                gadget.UnlockGadget(GadgetType.TORCH);
                gadget.UnlockGadget(GadgetType.STUN_GUN); break;
        }
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

    public int GetTotalCollection(){
        return player.GetComponent<PlayerInventory>().GetTotalItemValue();
    }
}
}
