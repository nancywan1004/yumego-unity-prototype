using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Projection _projection;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _force;
    [SerializeField] private Transform ShotPoint;
    [SerializeField] private Vector3 rotation;
    //[SerializeField] private Transform _barrelPivot;
    //[SerializeField] private float _rotateSpeed = 30;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       
        _projection.SimulateTrajectory(_ballPrefab, ShotPoint.position, ShotPoint.up * _force);
    }

    public void LaunchBall()
    {
        var spawned = Instantiate(_ballPrefab, ShotPoint.position, ShotPoint.rotation);

        spawned.Init(ShotPoint.up * _force, false);
    }

    public void IncreasePower()
    {
        _force += 10;
    }

    public void ReducePower()
    {
        _force -= 10;
       
    }

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

}
