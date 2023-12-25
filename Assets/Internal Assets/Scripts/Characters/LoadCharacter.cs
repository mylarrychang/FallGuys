using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;

	void Start()
	{
		if (characterPrefabs.Length == 0) return;

		Debug.Log("character prefabs: " + characterPrefabs.Length);
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		Debug.Log("In load character: selected: " + selectedCharacter);
		GameObject prefab = characterPrefabs[selectedCharacter];
		GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
		clone.SetActive(true);
		
		// Find the camera holder and assign the character to it.
		GameObject camera = GameObject.Find("Camera Holder");
		Debug.Log("finding::::: " + camera);
		CameraManager cameraManager = camera.GetComponent<CameraManager>();
		cameraManager.target = clone.transform;
	}
}
