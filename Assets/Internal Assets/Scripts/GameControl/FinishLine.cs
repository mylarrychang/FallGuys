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
            string startTime = PlayerPrefs.GetString(Constants.PLAYER_PREFAB_START_LEVEL_TIME);

            if (string.IsNullOrEmpty(startTime))
            {
                Debug.LogError("Unable to find `startLevelTime`..");
	        } else
	        {
                DateTime startDateTime = DateTime.Parse(startTime);
                int duration = (int)(DateTime.UtcNow - startDateTime).TotalSeconds;

                PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_LEVEL_DURATION_IN_SECONDS, duration);
                PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_COMPLETED_GAME_COUNT,
		            PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_COMPLETED_GAME_COUNT) + 1);
            }

            // Load the last one
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1, LoadSceneMode.Single);
	    }
    }
}
