using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    [SerializeField] private LayerMask inputLayer;
    [SerializeField] private LayerMask selectLayer;
    [SerializeField] private float inputHeightValue;
    private RaycastHit hit;
    private GameObject selectedObject;
    private ObjectBehaviour objectBehaviour;

    private void Update()
    {
        SelectObject();
        MoveObject();
        DeselectObject();
    }

    private void SelectObject()
    {
        if (Input.GetMouseButtonDown(0) && !selectedObject)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 300, selectLayer))
            {
                if (!selectedObject)
                {
                    selectedObject = hit.transform.gameObject;
                    objectBehaviour = selectedObject.GetComponent<ObjectBehaviour>();
                    objectBehaviour.selected = true;
                    StartCoroutine(objectBehaviour.SelectedRotation(1f));
                }
            }
        }
    }

    private void DeselectObject()
    {
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
            objectBehaviour.selected = false;
            StartCoroutine(objectBehaviour.GetFirstPlace(1f));
        }
    }
    private void MoveObject()
    {
        if (selectedObject)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100, inputLayer))
            {
                Vector3 movePosition = hit.point + Vector3.up * inputHeightValue;

                selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, movePosition, Time.fixedDeltaTime * 24f);
            }
        }
    }
}
