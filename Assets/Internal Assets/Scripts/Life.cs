using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int diffLife = 2;

    public void AddLife()
    {
        int curLife = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        curLife += diffLife;
        if (curLife > 5) curLife = 5;

        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_LIFE_COUNT, curLife);
    }
}
