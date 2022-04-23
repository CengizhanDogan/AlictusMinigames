using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyList : MonoBehaviour
{
    public List<BodyBehaviour> bodies = new List<BodyBehaviour>();

    private void Awake()
    {
        BodyBehaviour[] bodyArray = FindObjectsOfType<BodyBehaviour>();

        foreach (BodyBehaviour body in bodyArray)
        {
            bodies.Add(body);
        }
    }
}
