using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUiDisplay : MonoBehaviour
{
    public Image red;
    public Image gray;
    public GameObject[] imageGameObjects;

    private int lifeCount;

    // Start is called before the first frame update
    void Update()
    {
        lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);

        for (int i = 0; i < lifeCount; i++)
        {
            GameObject obj = imageGameObjects[i];
            obj.GetComponent<Image>().sprite = red.sprite;
	    }

        for (int i = lifeCount; i < imageGameObjects.Length; i++)
        { 
            GameObject obj = imageGameObjects[i];
            obj.GetComponent<Image>().sprite = gray.sprite;
	    }
    }
}
