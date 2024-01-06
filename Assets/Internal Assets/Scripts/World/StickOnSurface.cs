using UnityEngine;

public class StickOnSurface : MonoBehaviour
{
    private Transform parent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parent = collision.transform.parent;
            collision.transform.SetParent(transform);
	    }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = parent;
	    }
    }
}
