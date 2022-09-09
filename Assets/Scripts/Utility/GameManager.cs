using UnityEngine;

namespace ProfessionalThief{
public class GameManager : MonoBehaviour
{
    static GameManager instance;
    bool gameOver;
    int totalLevel;
    [SerializeField] GameObject sunlight;
    [SerializeField] PlayerController player;
    [SerializeField] GadgetController gadget;

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
        UnlockCollectedGadgets();
    }

    void UnlockCollectedGadgets(){
        LevelName levelName = Utils.GetActiveLevelName();
        switch(levelName){
            case LevelName.LEVEL2 : 
                gadget.UnlockGadget(GadgetType.TORCH); break;
            case LevelName.LEVEL3 : 
                gadget.UnlockGadget(GadgetType.TORCH);
                gadget.UnlockGadget(GadgetType.STUN_GUN); break;
        }
    }

    public void UnlockGadget(GadgetType gadgetType){
        gadget.UnlockGadget(gadgetType);
    }

    public bool IsGameOver(){
        return gameOver;
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

    public void LevelCompleted(){
        StopGame();
        PlayerPrefs.SetInt("ACTIVE_LEVEL", GetNextLevelIndex());
        UIManager.Instance().ShowLevelCompletedUI();
    }

    public int GetNextLevelIndex(){
        int nextLevelIndex = (int)Utils.GetActiveLevelName() + 1;
        if(nextLevelIndex == totalLevel)
            return 0;
        else
            return nextLevelIndex;
    }

    public void LoadNextLevel(){
        Utils.LoadLevel((LevelName)GetNextLevelIndex());
    }

    public int GetTotalCollection(){
        return player.GetComponent<PlayerInventory>().GetTotalItemValue();
    }
}
}
