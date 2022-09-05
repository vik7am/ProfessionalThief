using UnityEngine;

namespace ProfessionalThief{
public class GameManager : MonoBehaviour
{
    static GameManager instance;
    bool gameOver;
    [SerializeField] GameObject sunlight;
    [SerializeField] PlayerController player;

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

    public void GameOver(){
        gameOver = true;
        player.DisablePlayer();
        sunlight.SetActive(true);
        UIManager.Instance().ShowGameoverUI();
    }

    public bool IsGameOver(){
        return gameOver;
    }
}
}
