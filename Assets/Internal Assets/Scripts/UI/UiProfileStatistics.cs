using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiProfileStatistics : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI completedGamesText;

    // Start is called before the first frame update
    void Start()
    {
        int totalScore = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_SCORE);
        scoreText.text = totalScore.ToString();

        int completedGameCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_COMPLETED_GAME_COUNT);
        completedGamesText.text = completedGameCount.ToString();

        Debug.Log("total score: " + totalScore + " games: " + completedGameCount);
    }
}
