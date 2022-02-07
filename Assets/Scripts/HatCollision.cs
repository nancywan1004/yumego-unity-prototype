using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Obstacle")
        {
            Debug.Log("Goal!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
