using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControllerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform controlBone;
    private Rigidbody boneRb;

     public bool canFollowed;

    private void Start()
    {
        boneRb = controlBone.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Follow();
        BeFollowed();
    }

    public void Follow()
    {
        if (!canFollowed)
        {
            Vector3 followPos = controlBone.position;
            followPos.z = transform.position.z;
            
            transform.DOMove(followPos, 0f).SetEase(Ease.Linear);
        }
    }
    private void BeFollowed()
    {
        if (canFollowed)
        {
            Vector3 followPos = transform.position;
            followPos.z = controlBone.position.z;

            boneRb.transform.DOMove(followPos, 0.1f).SetEase(Ease.Linear);
        }
    }
}
