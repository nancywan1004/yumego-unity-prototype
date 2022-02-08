using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody ball;
    public float rotationSpeed = 2f;
    public Vector3 rotation;
    [SerializeField]
    public float shootPower;
    [SerializeField]
    public bool debugVelocity = false;
    public LineRenderer line;
    private Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        // line.gameObject.SetActive(false);
        initPosition = ball.position;
        line.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.position;
        transform.rotation = ball.rotation;
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.forward * 5);  //new Vector3(transform.position.x, transform.position.y, transform.position.x) - transform.forward * 5); 
        if (Input.GetKey(KeyCode.R))
        {
            ResetPosition();
        }
    }

    public void IncreasePower()
    {
        shootPower++;
    }

    public void ReducePower()
    {
        shootPower--;
    }

    public void LaunchBall()
    {
        ball.velocity = -transform.forward * shootPower;
        line.gameObject.SetActive(false);
    }

    public void RotateLeft()
    {
        //ball.transform.Rotate(rotation * 500 * Time.deltaTime);
        ball.transform.Rotate(0, -10, 0);

    }

    public void RotateRight()
    {
        ball.transform.Rotate(0, 10, 0);
    }

    public void RotateUp()
    {
        ball.transform.Rotate(10, 0, 0);
    }

    public void RotateDown()
    {
        ball.transform.Rotate(-10, 0, 0);
    }
    public void ResetPosition()
    {
        ball.position = initPosition;
        ball.velocity = Vector3.zero;
        line.gameObject.SetActive(true);

    }


}
