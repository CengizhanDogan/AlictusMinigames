using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool started;
    public Rigidbody rb;
    public float forwardSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetStarted();
        Move();
    }

    private void GetStarted()
    {
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
        }
    }

    private void Move()
    {
        if (started)
        {
            if (rb)
            {
                rb.transform.Translate(Vector3.forward * -forwardSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            }
        }
    }

}
