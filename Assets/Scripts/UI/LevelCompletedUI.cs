using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

namespace ProfessionalThief{
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
        SceneManager.LoadScene(0);
    }
}
}