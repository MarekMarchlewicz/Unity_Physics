using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRagdollOnHit : MonoBehaviour
{
    private void Start()
    {
        ToggleRigidbodies(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile"))
            ToggleRigidbodies(true);

        GetComponent<Collider>().enabled = false;
    }

    private void ToggleRigidbodies(bool enable)
    {
        foreach(Rigidbody rigidbody in GetComponentsInChildren<Rigidbody>())
        {
            rigidbody.isKinematic = !enable;
        }
    }
}
