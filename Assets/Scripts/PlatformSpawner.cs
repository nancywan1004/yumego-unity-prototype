using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlatformSpawner : MonoBehaviour
{
    public bool EnableDoubleTap = true;

    [SerializeField] private GameObject platformPrefab;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Platform"))
                {
                    Debug.Log("Hit collider is: " + hit.collider);
                    var objectScript = hit.collider.GetComponent<DragAndRotateCube>();
                    if (objectScript != null)
                    {
                        objectScript.isActive = !objectScript.isActive;
                    }
                }
                else
                {
                    // Need to implement a new inventory system to handle platform spawning
                    // Instantiate(platformPrefab, hit.point+ new Vector3(0, 1, 0), transform.rotation);
                }
            }
        }

        // Mouse control to rotate/instantiate platforms
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Platform"))
                {
                    Debug.Log("Hit collider is: " + hit.collider);
                    var objectScript = hit.collider.GetComponent<DragAndRotateCube>();
                    if (objectScript != null)
                    {
                        // object is highlighted red
                        objectScript.isActive = !objectScript.isActive;
                    }
                }
                else
                {
                    // Need to implement a new inventory system to handle platform spawning
                    // Instantiate(platformPrefab, hit.point+ new Vector3(0, 1, 0), transform.rotation);
                }
            }
        }
    }

}