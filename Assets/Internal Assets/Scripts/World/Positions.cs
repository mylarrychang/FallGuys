using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = Random.Range(0, 180);
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
