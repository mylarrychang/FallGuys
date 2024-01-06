using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WNDRotator : MonoBehaviour
{
    public Vector3 rotationSpeed;
    private void Start()
    {
        if (Random.Range(0, 2) < 1)
        {
            rotationSpeed = -rotationSpeed;
	    }
    }

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed);
    }
}
