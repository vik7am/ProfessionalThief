using UnityEngine;

namespace ProfessionalThief{
    public enum UIType {HUD, GAME_OVER, LEVEL_COMPLETED}
public class UIManager : GenericMonoSingleton<UIManager>
{
    static UIManager instance;
    [SerializeField] private HudUI hudUI;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private LevelCompletedUI levelCompletedUI;

    public HudUI Hud { get => hudUI;}
    public GameOverUI GameOver {get => gameOverUI;}
    public LevelCompletedUI levelCompleted {get => levelCompletedUI;}

    GameObject activeUI;

    private void Start() {
        ChangeUI(UIType.HUD);
    }

    public void ChangeUI(UIType uiType){
        if(activeUI != null)
            activeUI.SetActive(false);
        activeUI = GetUI(uiType);
        activeUI.SetActive(true);
    }

    public GameObject GetUI(UIType uiType){
        switch(uiType){
            case UIType.HUD : return hudUI.gameObject;
            case UIType.GAME_OVER : return gameOverUI.gameObject;
            case UIType.LEVEL_COMPLETED : return levelCompletedUI.gameObject;
            default : return null;
        }
    }

}
}
