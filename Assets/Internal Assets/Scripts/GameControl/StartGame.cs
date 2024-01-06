using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("current scen: " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void MainPage()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Ranking()
    {
        SceneManager.LoadScene(SceneManager.sceneCount - 1, LoadSceneMode.Single);
    }
}
