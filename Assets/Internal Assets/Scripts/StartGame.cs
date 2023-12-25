using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void Options()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
