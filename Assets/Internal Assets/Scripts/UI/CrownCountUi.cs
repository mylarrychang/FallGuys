using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrownCountUi : MonoBehaviour
{
    public TextMeshProUGUI crownsText;

    // Update is called once per frame
    public void Update()
    {
        int crowns = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS);
        crownsText.text = crowns.ToString();
    }
}
