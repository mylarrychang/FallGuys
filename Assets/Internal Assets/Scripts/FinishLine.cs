using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            string startTime = PlayerPrefs.GetString("startLevelTime");
            if (string.IsNullOrEmpty(startTime))
            {
                Debug.LogError("Unable to find `startLevelTime`..");
	        } else
	        {
                DateTime startDateTime = DateTime.Parse(startTime);
                int duration = (int)(DateTime.UtcNow - startDateTime).TotalSeconds;
                PlayerPrefs.SetInt("levelDurationInSeconds", duration);
                PlayerPrefs.SetInt("completedGameCount", PlayerPrefs.GetInt("completedGameCount") + 1);
            }

            // Load the last one
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1, LoadSceneMode.Single);
	    }
    }
}
