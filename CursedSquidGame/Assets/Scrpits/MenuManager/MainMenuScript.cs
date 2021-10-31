using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string scene;

    public void PlayGame()
    {
        GameManager.Instance.currentLevel = 1;
        SceneManager.LoadScene(scene); // Load Lv1 scene
    }

    public void ExitGame()
    {
        Application.Quit(); // quit game
    }

    public void Retry()
    {
        GameManager.Instance.currentLevel = 1;
        SceneManager.LoadScene(scene); // load current active scene
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu"); // return to main menu
    }

    public void NextLevel()
    {

        GameManager.Instance.currentLevel += 1; SceneManager.LoadScene(scene);
    }
}

