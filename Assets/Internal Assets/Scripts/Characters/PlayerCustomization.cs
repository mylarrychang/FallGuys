using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public Mesh[] meshes;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = meshes[selectedCharacter];

        Material[] mats = skinnedMeshRenderer.materials;
        mats[0] = materials[selectedCharacter];
        skinnedMeshRenderer.materials = mats;
    }
}
