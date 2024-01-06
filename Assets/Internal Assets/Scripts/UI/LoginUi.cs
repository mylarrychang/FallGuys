using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginUi : MonoBehaviour
{
    public GameObject loginButton;
    public GameObject startButton;
    public TextMeshProUGUI nameText;


    // Start is called before the first frame update
    void Start()
    {
        int isAuthed = PlayerPrefs.GetInt("isAuthed");
        if (isAuthed != 1) return;
        string userName = PlayerPrefs.GetString("userName");

        loginButton.SetActive(false);
        startButton.SetActive(true);
        nameText.text = userName;
    }
}
