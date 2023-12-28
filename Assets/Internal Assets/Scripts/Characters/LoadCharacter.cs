using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
	public Transform spawnPoint;
	public GameObject character;

	void Start()
	{
		GameObject clone = Instantiate(character, spawnPoint.position, Quaternion.identity);
		clone.SetActive(true);
	}
}
