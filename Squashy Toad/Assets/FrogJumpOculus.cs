using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJumpOculus : MonoBehaviour
{

    public float jumpElevationInDegrees = 45;
    public float jumpSpeedInCMPS = 5;
    public float jumpGroundClearance = 2;
    public float jumpSpeedTolerance = 5;

    void start()
    {

    }


    void Update()
    {
        bool isOnGround = Physics.Raycast(transform.position, -transform.up, jumpGroundClearance);
        Debug.DrawRay(transform.position, -transform.up * jumpGroundClearance);
        var speed = GetComponent<Rigidbody>().velocity.magnitude;
        bool isNearStationary = speed < jumpSpeedTolerance;
        if (isOnGround && isNearStationary)
        {
            var camera = GetComponentInChildren<Camera>();
            Debug.DrawRay(transform.position, camera.transform.forward, Color.blue);
            var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            Debug.DrawRay(transform.position, projectedLookDirection, Color.blue);
            var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
            var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInCMPS;
            Debug.DrawRay(transform.position, jumpVector, Color.blue);
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }
    }
}