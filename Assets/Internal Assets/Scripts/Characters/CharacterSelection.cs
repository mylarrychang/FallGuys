using Ricimi;
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
        selectedCharacter = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_SELECTED_CHARACTER);
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
        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_SELECTED_CHARACTER, selectedCharacter);
        int mapIndex = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_SELECTED_MAP);

        int lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        if(lifeCount > 0)
        { 
            SceneManager.LoadScene(mapIndex + 1, LoadSceneMode.Single);
	    }
        else
	    {
            gameObject.GetComponent<PopupOpener>().OpenPopup();
	    }
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
        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_SELECTED_CHARACTER, selectedCharacter);
        PlayerPrefs.SetInt("isClient", 0);

        // TODO: 2 is network level 1
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
