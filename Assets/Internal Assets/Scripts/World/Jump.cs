using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float gravity = 10.0f;
    public float jumpHeight = 2.0f;
    public GameObject target;

    public void Start()
    {
        BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
        BoxCollider targetBoxCollider = target.gameObject.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(targetBoxCollider.size.x, 0.1f, targetBoxCollider.size.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Playere jump
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
    }
}
