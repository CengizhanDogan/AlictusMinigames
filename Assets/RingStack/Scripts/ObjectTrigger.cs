using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private Ring_ObjectBehaviour obj;
    [SerializeField] private GameObject ghostRing;
    public GameObject myGhost;
    public bool canPlace;

    private void Start()
    {
        obj = GetComponent<Ring_ObjectBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BodyBehaviour bodyBehaviour))
        {
            //If already rings body or if body is full.
            if (bodyBehaviour.containingRings.Contains(gameObject)
                || bodyBehaviour.containingRings.Count > 2) return;
            //
            CheckAndPlaceTheRing(bodyBehaviour);
        }
    }

    private void CheckAndPlaceTheRing(BodyBehaviour _bb)
    {
        if (_bb.containingRings.Count > 0)
        {
            Ring_ObjectBehaviour lastRing = _bb.containingRings[_bb.containingRings.Count - 1].GetComponent<Ring_ObjectBehaviour>();

            if (lastRing.color == obj.color)
            {
                //Potential next body. If player release the finger ring will drop down on this body.
                obj.futureBody = _bb;
                canPlace = true;
                //

                Vector3 spawnPos = lastRing.transform.position;

                spawnPos.y += 1.8f;

                myGhost = Instantiate(ghostRing, spawnPos, ghostRing.transform.rotation);
            }
            else
            {
                canPlace = false;
                obj.futureBody = null;
            }
        }
        else
        {
            //Same but in this condition body has no ring on it. So if the ring releases it goes to the first spot.
            obj.futureBody = _bb;
            canPlace = true;

            Vector3 spawnPos = _bb.transform.position;

            spawnPos.y = 0.8f;

            myGhost = Instantiate(ghostRing, spawnPos, ghostRing.transform.rotation);
            //
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BodyBehaviour bodyBehaviour))
        {
            canPlace = false;
            obj.futureBody = null;
            Destroy(myGhost);
        }
    }
}
