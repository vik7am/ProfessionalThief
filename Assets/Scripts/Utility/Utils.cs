using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ProfessionalThief{
public class Utils 
{
    public static LevelName GetActiveLevelName(){
        return (LevelName)SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadLevel(LevelName levelName){
        SceneManager.LoadScene((int)levelName);
    }

    public static void ReloadLevel(){
        LoadLevel(GetActiveLevelName());
    }
}
}