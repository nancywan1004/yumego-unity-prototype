using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 initPosition;
    private Quaternion initRotation;
    public Transform target;
    public ControlPoint ballController; 

    public float speed = 15f;

    private void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (ballController != null && !ballController.isBallRest())
        // {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
            // if (ballController.isBallLaunching())
            // {
                transform.rotation = Quaternion.Lerp(transform.rotation,  target.rotation, speed * Time.deltaTime);
        //     }
        // }

        
    }

    public void ResetPosition()
    {
        transform.position = initPosition;
        transform.rotation = initRotation;
    }
}
