using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        sunlight.SetActive(true);
        player.DisablePlayer();
        UIManager.Instance().ShowGameoverUI();
    }

    public bool IsGameOver(){
        return gameOver;
    }
}
