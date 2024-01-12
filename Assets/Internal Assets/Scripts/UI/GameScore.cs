using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Calculates game duration
public class GameScore : MonoBehaviour
{
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI addedCoinText;
    public TextMeshProUGUI addedCrownText;

    // Start is called before the first frame update
    void Start()
    {
        int duration = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LEVEL_DURATION_IN_SECONDS);

        // TODO: add difficulty as a parameter before 1000.
        if (duration < 10) {
            duration = 10;
	    }

        int addedCoin = (1000 / duration);
        int addedCrown = Math.Min(5, addedCoin / 10);

        PlayerPrefs.SetInt(
	        Constants.PLAYER_PREFAB_TOTAL_CROWNS,
            PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS) + addedCrown
        );
        PlayerPrefs.SetInt(
	        Constants.PLAYER_PREFAB_TOTAL_COINS,
            PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_COINS) + addedCoin
	    );

        durationText.text =  duration + " seconds";
        addedCoinText.text = addedCoin.ToString();
        addedCrownText.text = addedCrown.ToString();
    }
}
