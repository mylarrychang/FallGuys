using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Style style;
    private int selectedCharacter = 0;

    private void UpdateCharacter()
    { 
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = style.meshes[selectedCharacter];

        Material[] mats = skinnedMeshRenderer.materials;
        mats[0] = style.materials[selectedCharacter];
        skinnedMeshRenderer.materials = mats;
    }

    public void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        UpdateCharacter();
    }

    public void NextCharacter()
    {
        Debug.Log("In next character: " + selectedCharacter);
        selectedCharacter = (selectedCharacter + 1) % style.meshes.Length;
        UpdateCharacter();
    }

    public void PreviousCharacter()
    {
        Debug.Log("In previous character: " + selectedCharacter);
        selectedCharacter = (--selectedCharacter + style.meshes.Length) % style.meshes.Length;
        UpdateCharacter();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        int mapIndex = PlayerPrefs.GetInt("selectedMap");
        SceneManager.LoadScene(mapIndex + 1, LoadSceneMode.Single);
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
