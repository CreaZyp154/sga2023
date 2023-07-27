using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    

    public void Play()
    {
        SceneManager.LoadScene("Camille");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DeadPlayer()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
