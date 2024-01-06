using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Transform player;
    public Image image;

    // Update is called once per frame
    void Update()
    {
        float percentage = (player.transform.position.z - startPoint.transform.position.z) / (endPoint.transform.position.z - startPoint.transform.position.z);
        image.fillAmount = percentage;
        // Debug.Log("game progress: " + percentage);
    }
}
