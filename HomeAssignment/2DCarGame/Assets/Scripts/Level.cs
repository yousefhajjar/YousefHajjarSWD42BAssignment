using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad(string scene)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(scene);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver"));
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadWinScene()
    {
        StartCoroutine(WaitAndLoad("WinScene"));
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("2DCarGame");

        FindObjectOfType<GameSession>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
