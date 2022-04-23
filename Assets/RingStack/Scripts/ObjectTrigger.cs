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
            if (bodyBehaviour.containingRings.Contains(gameObject)
                || bodyBehaviour.containingRings.Count > 2) return;

            if (bodyBehaviour.containingRings.Count > 0)
            {
                Ring_ObjectBehaviour lastRing = bodyBehaviour.containingRings[bodyBehaviour.containingRings.Count - 1].GetComponent<Ring_ObjectBehaviour>();

                if (lastRing.color == obj.color)
                {
                    obj.futureBody = bodyBehaviour;
                    canPlace = true;

                    Vector3 spawnPos = lastRing.transform.position;

                    spawnPos.y += 1.8f;

                    Destroy(myGhost);
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
                obj.futureBody = bodyBehaviour;
                canPlace = true;

                Vector3 spawnPos = bodyBehaviour.transform.position;

                spawnPos.y = 0.8f;

                myGhost = Instantiate(ghostRing, spawnPos, ghostRing.transform.rotation);
            }
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
