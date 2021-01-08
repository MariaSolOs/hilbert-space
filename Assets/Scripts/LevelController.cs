using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
