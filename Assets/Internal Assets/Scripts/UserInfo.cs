using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;


    // Start is called before the first frame update
    void Start()
    {
        string userName = PlayerPrefs.GetString("userName");
        nameText.text = userName;
    }
}
