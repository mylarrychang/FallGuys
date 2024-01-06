using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        // Clean up all of the PlayerPrefs when quiting the game..
        Debug.Log("[Debug] Should only be started once");
        // PlayerPrefs.DeleteAll();
    }
}
