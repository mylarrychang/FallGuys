using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUi : MonoBehaviour
{
    public Image red;
    public Image gray;
    public GameObject[] heartArray;

    private int lifeCount;

    // Start is called before the first frame update
    void Update()
    {
        lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);

        for (int i = 0; i < lifeCount; i++)
        {
            GameObject obj = heartArray[i];
            obj.GetComponent<Image>().sprite = red.sprite;
	    }

        for (int i = lifeCount; i < heartArray.Length; i++)
        { 
            GameObject obj = heartArray[i];
            obj.GetComponent<Image>().sprite = gray.sprite;
	    }
    }
}
