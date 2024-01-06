using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public GameObject player;
    public void Start()
    {
        string startTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
        PlayerPrefs.SetString(Constants.PLAYER_PREFAB_START_LEVEL_TIME, startTime);

        Debug.Log("Starting level at UTC: " + startTime);
    }

    public void Update()
    {
        int lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        player.SetActive(lifeCount > 0);
    }
}
