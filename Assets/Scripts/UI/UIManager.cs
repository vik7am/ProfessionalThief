using UnityEngine;

namespace ProfessionalThief.V1{
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    [SerializeField] HudUI hudUI;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] LevelCompletedUI levelCompletedUI;

    public static UIManager Instance(){
        return instance;
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateCollectableValue(int value){
        hudUI.UpdateCollectableValue(value);
    }

    public void UpdateItemInfo(string info){
        hudUI.UpdateItemInfo(info);
    }

    public void UpdateActionLog(string text){
        hudUI.UpdateActionLog(text);
    }

    public void UpdateEquippedGadget(GadgetType gadget, int charge){
        hudUI.UpdateEquippedGadget(gadget, charge);
    }

    public void UpdateAvailableBattery(int value){
        hudUI.UpdateAvailableBattery(value);
    }

    public void UpdateChargeStatus(float value){
        hudUI.UpdateChargeStatus(value);
    }

    public void ShowGameoverUI(){
        hudUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
    }

    public void ShowLevelCompletedUI(){
        hudUI.gameObject.SetActive(false);
        levelCompletedUI.gameObject.SetActive(true);
        levelCompletedUI.UpdateTotalCollection();
    }
}
}
