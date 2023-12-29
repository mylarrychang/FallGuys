using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;
using TMPro;

public class OAuthLogin : MonoBehaviour
{
    public string ip;
    // public string clientId;
    public GameObject loginButton;
    public GameObject startButton;
    public TextMeshProUGUI nameText;

    WebSocket ws;
    bool isAuthed = false;
    /** Will be returned from the ws server.. */ 
    string type;
    string userId;
    string userName;

    public void Login()
    {
        string clientId = System.Guid.NewGuid().ToString();
        string loginUrl = "http://" + ip + ":8080/v1/auth/github/login";

        Debug.Log("Connecting to websocket using clientId: " + clientId);
        Debug.Log("Connecting to websocket using ip: " + ip);
        ws = new WebSocket("ws://" + ip + ":8081?clientId=" + clientId);
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            /*
            string json = e.Data;
            dynamic userInfo = JsonConvert.DeserializeObject(json);
            type = userInfo.type;
            userId = userInfo.user_id;
            userName = userInfo.user_name;
            displayName = userInfo.display_name;
            */
            string[] data = e.Data.Split(",");
            type = data[0];
            userId = data[1];
            userName = data[2];

            isAuthed = true;

            Debug.Log("Is auth: " + isAuthed + " type: " + type + " userId: " + userId + " userName: " + userName);
        };

        Application.OpenURL(loginUrl + "/" + clientId);
    }

    public void Update()
    {
        if (!isAuthed) return;
        // close the socket when is authorized
        ws.Close();
        Debug.Log("is authorized...");

        PlayerPrefs.SetInt("isAuthed", 1);
        PlayerPrefs.SetString("userName", userName);

        loginButton.SetActive(false);
        startButton.SetActive(true);
        nameText.text = userName;
    }
}

