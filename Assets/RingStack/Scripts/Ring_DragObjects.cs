using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_DragObjects : MonoBehaviour
{
    [SerializeField] private LayerMask inputLayer;
    [SerializeField] private LayerMask selectLayer;
    [SerializeField] private float inputHeightValue;
    [SerializeField] private Camera cam;
    private RaycastHit hit;
    private GameObject selectedObject;

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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 300, selectLayer))
            {
                if (!selectedObject)
                {
                    selectedObject = hit.transform.gameObject;
                    if (selectedObject.TryGetComponent(out Ring_ObjectBehaviour obj))
                    {
                        obj.selected = true;
                        StartCoroutine(obj.SelectedRotation(1f));
                    }
                }
            }
        }
    }

    private void DeselectObject()
    {
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            if (selectedObject.TryGetComponent(out Ring_ObjectBehaviour obj))
            {
                obj.selected = false;
                StartCoroutine(obj.GetFirstPlace(1f));
            }
            selectedObject = null;
        }
    }
    private void MoveObject()
    {
        if (selectedObject)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100, inputLayer))
            {
                Vector3 movePosition = hit.point + Vector3.up * inputHeightValue;

                selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, movePosition, Time.fixedDeltaTime * 24f);
            }
        }
    }
}
