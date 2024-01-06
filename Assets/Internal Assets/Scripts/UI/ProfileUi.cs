using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileUi : MonoBehaviour
{
    public void CloseWindow()
    {
        int lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        if (lifeCount <= 0)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
	    }
    }
}
