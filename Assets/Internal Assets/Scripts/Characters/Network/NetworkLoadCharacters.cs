using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkLoadCharacters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int isClient = PlayerPrefs.GetInt("isClient");

        if (isClient == 0)
        { 
            Debug.Log("Starting as a client..");
            NetworkManager.Singleton.StartClient();
	    }
        else
        {
            Debug.Log("Starting as a host..");
            NetworkManager.Singleton.StartHost();
	    }
    }
}
