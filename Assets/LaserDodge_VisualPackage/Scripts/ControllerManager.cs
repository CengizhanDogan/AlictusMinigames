using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private List<ControllerBehaviour> controllers = new List<ControllerBehaviour>();

    private void Start()
    {
        SetControllersToBones();
    }

    private void SetControllersToBones()
    {
        foreach (var controller in controllers)
        {
            controller.Follow();
        }
    }

    public void EnableControllers()
    {
        foreach (var controller in controllers)
        {
            Vector3 visibleSize = new Vector3(0.5f,0.5f,0.1f);

            controller.transform.DOScale(visibleSize, 0.25f);

            controller.canFollowed = true;
        }
    }
}
