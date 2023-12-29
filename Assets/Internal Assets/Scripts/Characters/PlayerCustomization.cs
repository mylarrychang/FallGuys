using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public Style style;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        Debug.Log("Selected character id: " + selectedCharacter + ", name: " + style.names[selectedCharacter]);
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = style.meshes[selectedCharacter];

        Material[] mats = skinnedMeshRenderer.materials;
        mats[0] = style.materials[selectedCharacter];
        skinnedMeshRenderer.materials = mats;
    }
}
