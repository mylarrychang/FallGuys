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
        int totalScore = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_COINS);
        scoreText.text = totalScore.ToString();

        int crownCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS);
        completedGamesText.text = crownCount.ToString();

        Debug.Log("total score: " + totalScore + " crowns: " + crownCount);
    }
}
