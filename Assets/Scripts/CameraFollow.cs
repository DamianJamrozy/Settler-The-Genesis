using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // public Transform target;
    // public Vector3 offset;
    // public float smoothFactor = 0.5f;

    // public bool lookAtTarget = false;
    
    // void Start()
    // {
    // }

    // void LateUpdate()
    // {
    //     Vector3 newPos = target.transform.position + offset;
    //     transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, smoothFactor);

    //     if(lookAtTarget)
    //     {
    //         transform.LookAt(target);
    //     }
    // }

    public Transform target;
    public float pLerp = .02f;
    public float rLerp = .01f;
    
    public Camera mainCam;

    void Awake()
    {
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rLerp);
        
        ZoomCamera();
    }
    
    void ZoomCamera()
    {
        if(Input.GetButton("Fire2"))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, 20, 3 * Time.deltaTime);

        }else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, 60, 3 * Time.deltaTime);
        }
    }


}
