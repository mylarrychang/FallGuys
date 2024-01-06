using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public Image[] maps;
    private int selectedMap = 0;

    private void UpdateMap()
    {
        Image curImage = gameObject.GetComponent<Image>();
        curImage.sprite = maps[selectedMap].sprite;
    }

    public void Start()
    {
        selectedMap = PlayerPrefs.GetInt("selectedMap");
        UpdateMap();
    }

    public void NextMap()
    {
        Debug.Log("In next map: " + selectedMap);
        selectedMap = (selectedMap + 1) % maps.Length;
        PlayerPrefs.SetInt("selectedMap", selectedMap);
        UpdateMap();
    }

    public void PreviousMap()
    {
        Debug.Log("In previous map: " + selectedMap);
        selectedMap = (--selectedMap + maps.Length) % maps.Length;
        PlayerPrefs.SetInt("selectedMap", selectedMap);
        UpdateMap();
    }
}
