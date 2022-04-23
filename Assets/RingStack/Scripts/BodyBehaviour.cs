using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour
{
    public List<GameObject> containingRings = new List<GameObject>();

    public void CheckList()
    {
        int sameRingCount = 0;
        Ring_ObjectBehaviour obj = null;

        foreach (GameObject ring in containingRings)
        {
            if (obj == null)
            {
                obj = ring.GetComponent<Ring_ObjectBehaviour>();
            }
            else if (obj.color == ring.GetComponent<Ring_ObjectBehaviour>().color)
            {
                sameRingCount++;
            }
        }
        if (sameRingCount == 2)
        {
            WinChecker.Instance.correctCount++;
            WinChecker.Instance.CheckIfWon();
        }
    }
}
