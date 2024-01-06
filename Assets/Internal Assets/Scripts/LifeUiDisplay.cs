using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUiDisplay : MonoBehaviour
{
    public Image red;
    public GameObject[] imageGameObjects;
    public int lifeCount;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lifeCount; i++)
        {
            GameObject obj = imageGameObjects[i];
            obj.GetComponent<Image>().sprite = red.sprite;
	    }
    }
}
