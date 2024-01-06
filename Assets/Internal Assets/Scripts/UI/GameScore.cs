using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Calculates game duration
public class GameScore : MonoBehaviour
{
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI oldScoreText;
    public TextMeshProUGUI addedScoreText;
    public TextMeshProUGUI newScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int duration = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LEVEL_DURATION_IN_SECONDS);
        // TODO: add difficulty as a parameter before 1000.
        if (duration < 10) {
            duration = 10;
	    }

        int addedScore = (1000 / duration);

        int oldScore = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_SCORE);
        int newScore = oldScore + addedScore;
        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_TOTAL_SCORE, newScore);

        Debug.Log("the duration: " + duration);

        durationText.text =  duration + " seconds";
        oldScoreText.text = oldScore.ToString();
        newScoreText.text = newScore.ToString();
        addedScoreText.text = addedScore.ToString();
    }
}
