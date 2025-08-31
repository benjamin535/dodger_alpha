using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // go back to Main Menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // restart current level 
    public void RetryLevel()
    {
        string currentScene = PlayerPrefs.GetString("LastLevel", "Level1");
        SceneManager.LoadScene(currentScene);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // load How to play 
    public void HowToPlay()
    {
        SceneManager.LoadScene("How");
    }

    public void Level_1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level_2()
    {
        SceneManager.LoadScene("Level2");
    }
}
