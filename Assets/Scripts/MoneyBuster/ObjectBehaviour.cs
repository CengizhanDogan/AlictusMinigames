using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    [SerializeField] private Quaternion selectedRot;

    [HideInInspector] public bool selected;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public IEnumerator GetFirstPlace(float _time)
    {
        float currentTime = 0;
        while (currentTime / _time < 1f && !selected)
        {
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, startPos, currentTime / _time);
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, currentTime / _time);
            yield return null;
        }
    }
    public IEnumerator SelectedRotation(float _time)
    {
        float currentTime = 0;
        while (currentTime / _time < 1f && selected)
        {
            currentTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, selectedRot, currentTime / _time);
            yield return null;
        }
    }
}
