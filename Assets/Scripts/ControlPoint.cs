using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    private float xRot, yRot = 0f;
    private Vector3 initPosition;

    public Rigidbody ball;
    public float rotationSpeed = 2f;
    [SerializeField] 
    public float shootPower;
    [SerializeField]
    public bool debugVelocity = false;
    public LineRenderer line;

    private void Start()
    {
        // line.gameObject.SetActive(false);
        initPosition = ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.position;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
            if (yRot < -35f)
            {
                yRot = -35f;
            }
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position - transform.forward * 4);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ball.velocity = -transform.forward * shootPower;
            line.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            ResetPosition();
        }

        if (debugVelocity)
        {
            Debug.Log("current velocity: " + ball.velocity);
        }
        
    }

    public void ResetPosition()
    {
        ball.position = initPosition;
        ball.velocity = Vector3.zero;
    }

    public void AdjustPower(float power)
    {
        shootPower = power;
    }
}
