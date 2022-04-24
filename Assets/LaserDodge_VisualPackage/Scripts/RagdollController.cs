using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private List<Rigidbody> childRigidbodies = new List<Rigidbody>();
    private List<Collider> childColliders = new List<Collider>();
    //private List<Transform> childTransforms = new List<Transform>();
    //private List<Vector3> childPosition = new List<Vector3>();
    void Start()
    {
        GetRigidbodyAndCollider();
        RagdollControl(false);
    }
    private void GetRigidbodyAndCollider()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        Collider[] colliders = GetComponentsInChildren<Collider>();
        Transform[] transforms = GetComponentsInChildren<Transform>();

        foreach (Rigidbody _rigidbody in rigidbodies) childRigidbodies.Add(_rigidbody);

        foreach (Collider _collider in colliders) childColliders.Add(_collider);
        
        //foreach (Transform _transform in transforms) childTransforms.Add(_transform);

        //foreach (Transform _transform in childTransforms) childPosition.Add(_transform.position);
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

    //public void ResetTransform()
    //{
    //    for (int i = 0; i < childTransforms.Count; i++)
    //    {
    //        childTransforms[i].position = childPosition[i];
    //    }
    //}
}
