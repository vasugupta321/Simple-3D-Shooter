using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //the position which camera will follow
    public float smoothing = 5f; //speed with which will the camera will be following

    Vector3 offset; //initial offset from the target

    void Start()
    {
        //calculating initial offset
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        //creates position camera is aiming for based on offset from target
        Vector3 targetCamPos = target.position + offset;
        //smoothly move back and forth between camera's current position and target position
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
