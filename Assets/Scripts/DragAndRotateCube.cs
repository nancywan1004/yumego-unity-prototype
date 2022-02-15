using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndRotateCube : MonoBehaviour
{
    public bool isActive = false;
    Color activeColor = new Color();

    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    public bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        _sensitivity = 0.4f;
        _rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            activeColor = Color.red;

            // Enter mouse rotation
            if (isRotating)
            {
                // offset
                _mouseOffset = (Input.mousePosition - _mouseReference);

                // apply rotation
                _rotation.y = -(_mouseOffset.x) * _sensitivity;
                _rotation.x = (_mouseOffset.y) * _sensitivity;

                // rotate
                // transform.Rotate(_rotation);
                transform.eulerAngles += _rotation;
                // store mouse
                _mouseReference = Input.mousePosition;
            }

            // Enter touch rotation
            if (Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);

                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(screenTouch.deltaPosition.y, screenTouch.deltaPosition.x, 0f);
                }

                if (screenTouch.phase == TouchPhase.Ended)
                {
                    isActive = false;
                }
            }
        }
        else
        {
            activeColor = Color.white;
        }

        GetComponent<MeshRenderer>().material.color = activeColor;
    }

    void OnMouseDown()
    {
        if (isActive)
        {
            // rotating flag
            isRotating = true;

            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseUp()
    {
        if (isActive)
        {
            // rotating flag
            isRotating = false;
        }
    }

}