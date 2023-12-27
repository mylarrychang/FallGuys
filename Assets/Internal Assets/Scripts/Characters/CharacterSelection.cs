using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        Debug.Log("In next character: " + selectedCharacter);
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        Debug.Log("In previous character: " + selectedCharacter);
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (--selectedCharacter + characters.Length) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartNetworkGameHost()
    {

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.SetInt("isClient", 1);


        // TODO: 2 is network level 1
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void StartNetworkGameClient()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.SetInt("isClient", 0);

        // TODO: 2 is network level 1
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
