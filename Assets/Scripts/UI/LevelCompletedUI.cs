using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace ProfessionalThief.V1{
public class LevelCompletedUI : MonoBehaviour
{
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button quitButton;
    [SerializeField] TextMeshProUGUI collection;
    
    void Start()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void UpdateTotalCollection(){
        collection.text = "Collected $" +  GameManager.Instance().GetTotalCollection();
    }

    void LoadNextLevel(){
        GameManager.Instance().LoadNextLevel();
    }

    void QuitGame(){
        Utils.LoadLevel(LevelName.MAIN_MENU);
    }
}
}