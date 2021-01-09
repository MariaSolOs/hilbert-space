using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
}
