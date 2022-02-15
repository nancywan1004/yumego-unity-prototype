using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public GameObject Ball;
    public Transform ShotPoint;
    public float rotationSpeed = 2f;
    public Vector3 rotation;
    [SerializeField]
    public float shootPower;
    [SerializeField]
    public bool debugVelocity = false;
    //public LineRenderer line;
    private Vector3 initPosition;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // line.gameObject.SetActive(false);
        initPosition = transform.position;
        //line.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = ball.position;
        //transform.rotation = ball.rotation;
        
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.forward * 5);  //new Vector3(transform.position.x, transform.position.y, transform.position.x) - transform.forward * 5); 
        //if (Input.GetKey(KeyCode.R))
        //{
        //    ResetPosition();
        //}





    }

    public void IncreasePower()
    {
        shootPower++;
    }

    public void ReducePower()
    {
        shootPower--;
    }

    //public void LaunchBall()
    //{
    //    //velocity = -transform.forward * shootPower;
    //    //line.gameObject.SetActive(false);
    //    //GameObject CreatedBall = Instantiate(Ball, ShotPoint.position, ShotPoint.rotation);
    //    //CreatedBall.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * shootPower;



    //}

    public void RotateLeft()
    {
        //ball.transform.Rotate(rotation * 500 * Time.deltaTime);
        transform.Rotate(0, -10, 0);

    }

    public void RotateRight()
    {
        transform.Rotate(0, 10, 0);
    }

    public void RotateUp()
    {
        transform.Rotate(-10, 0, 0);
    }

    public void RotateDown()
    {
        transform.Rotate(10, 0, 0);
    }
    public void ResetPosition()
    {
        
        //transform.position = initPosition;
        velocity = Vector3.zero;
        //line.gameObject.SetActive(true);

    }


}
