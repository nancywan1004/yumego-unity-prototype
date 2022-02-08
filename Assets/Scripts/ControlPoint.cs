using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPoint : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody rb;
    public float rotationSpeed = 2f;
    
    [SerializeField] 
    private float shootPower;
    [SerializeField]
    private bool debugVelocity = false;
    
    public LineRenderer line;
    public Slider slider;
    public TMP_Text powerValue;
    
    private float xRot, yRot = 0f;
    private Vector3 initPosition;
    private Vector3 initVelocity;
    private Quaternion initRotation;

    private enum State
    {
        Rest,
        Launching,
        Launched,
    }

    private State _state;

    private void Awake()
    {
        rb = ball.GetComponent<Rigidbody>();
        _state = State.Rest;
    }

    private void Update()
    {
        transform.position = rb.position;
        transform.rotation = rb.rotation;
    }

    private void Start()
    {
        initVelocity = rb.velocity;
        initPosition = rb.position;
        initRotation = rb.rotation;
    }

    public void ResetPosition()
    {
        rb.position = initPosition;
        rb.velocity = initVelocity;
        rb.rotation = initRotation;
        _state = State.Rest;
    }

    public void LaunchBall()
    {
        // if (_state == State.Launching)
        // {
            rb.velocity = -transform.forward * shootPower;
            line.gameObject.SetActive(false);
            _state = State.Launched;
        // }
    }
    public void AdjustPower(float power)
    {
        shootPower = power;
        powerValue.text = power.ToString();
        _state = State.Launching;
    }

    public bool isBallLaunching()
    {
        return _state == State.Launching;
    }
    
    public bool isBallRest()
    {
        return _state == State.Rest;
    }

    public void SetLaunchingMode()
    {
        _state = State.Launching;
    }
}
