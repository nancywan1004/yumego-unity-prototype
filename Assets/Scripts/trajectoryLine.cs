using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectoryLine : MonoBehaviour
{
    BallController ballController;
    
    LineRenderer lineRenderer;

    public int numPoints = 50;

    public float timeBetweenPoints = 0.1f;

    public LayerMask CollidableLayers;

    // Start is called before the first frame update
    void Start()
    {
        //ballController = GetComponent<BallController>();
        //lineRenderer = ballController.line;

    }

    // Update is called once per frame
    void Update()
    {
        //lineRenderer.positionCount = (int)numPoints;
        //List<Vector3> points = new List<Vector3>();
        //Vector3 startingPosition = ballController.ball.position;
        //Vector3 startingVelocity = ballController.ball.transform.forward * ballController.shootPower;
        //for (float t = 0; t < numPoints; t += timeBetweenPoints)
        //{
        //    Vector3 newPoint = startingPosition + t * startingVelocity;
        //    newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
        //    points.Add(newPoint);

        //    if(Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
        //    {
        //        lineRenderer.positionCount = points.Count;
        //        break;
        //    }
        //}

        //lineRenderer.SetPositions(points.ToArray());
    }
}
