using System;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public void Start()
    {
        string startTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
        PlayerPrefs.SetString(Constants.PLAYER_PREFAB_START_LEVEL_TIME, startTime);

        Debug.Log("Starting level at UTC: " + startTime);
    }
}
