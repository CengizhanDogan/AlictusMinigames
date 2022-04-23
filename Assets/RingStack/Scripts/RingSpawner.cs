using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> rings = new List<GameObject>();

    private BodyList bodyList;

    private GameObject ringOne;
    private GameObject ringTwo;

    private float yValue = 0.8f;
    [SerializeField] private float yPlusValue = 1.8f;

    private void Awake()
    {
        bodyList = GetComponent<BodyList>();
    }
    private void Start()
    {
        SelectTwoRings();
        SpawnRings();
    }

    private void SelectTwoRings()
    {
        ringOne = rings[Random.Range(0, rings.Count - 1)];
        ringTwo = rings[Random.Range(0, rings.Count - 1)];

        while (ringOne == ringTwo)
        {
            ringTwo = rings[Random.Range(0, rings.Count)];
        }
    }

    private void SpawnRings()
    {
        for (int i = 0; i < 3; i++)
        {
            BodyBehaviour selectedBody = RandomBody();
            GameObject ringClone = Instantiate(ringOne, SpawnPos(selectedBody), ringOne.transform.rotation, transform);
            selectedBody.containingRings.Add(ringClone);

        }
        for (int a = 0; a < 3; a++)
        {
            BodyBehaviour selectedBody = RandomBody();
            GameObject ringClone = Instantiate(ringTwo, SpawnPos(selectedBody), ringOne.transform.rotation, transform);
            selectedBody.containingRings.Add(ringClone);
        }
    }
    private BodyBehaviour RandomBody()
    {
        BodyBehaviour randomBody = bodyList.bodies[Random.Range(0, 2)];
        while (randomBody.containingRings.Count == 2)
        {
            randomBody = bodyList.bodies[Random.Range(0, 2)];
        }
        return randomBody;
    }
    private Vector3 SpawnPos(BodyBehaviour _randomBody)
    {
        Vector3 bodyPos = _randomBody.transform.position;
        bodyPos.y = yValue + (_randomBody.containingRings.Count - 1 * yPlusValue);
        Debug.Log(bodyPos.y);
        return bodyPos;
    }
}
