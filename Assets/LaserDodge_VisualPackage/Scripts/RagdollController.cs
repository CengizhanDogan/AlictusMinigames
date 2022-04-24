using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private List<Rigidbody> childRigidbodies = new List<Rigidbody>();
    private List<Collider> childColliders = new List<Collider>();
    void Start()
    {
        GetRigidbodyAndCollider();
        RagdollConstrains();
        RagdollControl(false);
    }
    private void GetRigidbodyAndCollider()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Rigidbody rigidbody in rigidbodies) childRigidbodies.Add(rigidbody);

        foreach (Collider collider in colliders) childColliders.Add(collider);
    }
    private void RagdollConstrains()
    {
        foreach (Rigidbody rigidbody in childRigidbodies)
        {
           rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }

    public void RagdollControl(bool enable)
    {
        foreach (Rigidbody rigidbody in childRigidbodies)
        {
            rigidbody.isKinematic = !enable;
            rigidbody.useGravity = false;
        }

        foreach (Collider collider in childColliders) collider.enabled = enable;
    }

}
