using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour {

    public float jumpElevationInDegrees = 45;
    public float[] jumpSpeedInCMPS = {200, 400, 700};
    public float jumpGroundClearance = 2;
    public float jumpSpeedTolerance = 5;

    public int collisionCount = 0;
    public int hopCount = 0;

    void start()
    {

    }
 void OnCollisionEnter()
    {
        collisionCount = collisionCount + 1;
    }
    void OnCollisionExit()
    {
        collisionCount--;
    }
    void Update() {
        bool isOnGround = collisionCount > 0; //or less than 3;

        if (isOnGround)
        {
            hopCount = 0;
        }

        if (GvrViewer.Instance.Triggered && hopCount < jumpSpeedInCMPS.Length)
        {
            var camera = GetComponentInChildren<Camera>();
            Debug.DrawRay(transform.position, camera.transform.forward, Color.blue);
            var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            Debug.DrawRay(transform.position, projectedLookDirection, Color.blue);
            var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
            var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInCMPS[hopCount];
            Debug.DrawRay(transform.position, jumpVector, Color.blue);
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);

            hopCount++;
        }
     
    }
  }

//bool isOnGround = Physics.Raycast(transform.position, -transform.up, jumpGroundClearance);
//Debug.DrawRay(transform.position, -transform.up* jumpGroundClearance);