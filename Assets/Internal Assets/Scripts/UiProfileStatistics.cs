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
        int totalScore = PlayerPrefs.GetInt("totalScore");
        scoreText.text = totalScore.ToString();

        int completedGameCount = PlayerPrefs.GetInt("completedGameCount");
        completedGamesText.text = completedGameCount.ToString();

        Debug.Log("total score: " + totalScore + " games: " + completedGameCount);
    }
}
