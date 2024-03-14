using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float targetInSkyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(targetPoint.position);
    }
}
