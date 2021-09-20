using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementFPS : MonoBehaviour
{
    // x for l/r, y for f/b
    public Vector2 moveInputVector;
    // x for rotate l/r, y for look u/d
    public Vector2 lookInputVector;

    public Transform lookTransformPoint;


    // Movement and Look Variables
    public float moveSpeed = 25;
    public float turnSpeed = 200;

    public float lookRotateDirection = 0;
    public float maxVerticalLookAngle = 80;
    public float lookVerticalDirection = 0;

    public float velocity = 0;
    public float gravity = 9.8f;

    public CharacterController characterController;

    void Start() {
        characterController = GetComponent<CharacterController>();
        lookTransformPoint = transform.Find("visor").transform;
    }

    void OnMove(InputValue iv) {
        moveInputVector = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        lookInputVector = iv.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        /*lookRotateDirection += lookInputVector.x;
        lookRotateDirection = Mathf.Clamp(lookRotateDirection, -turnSpeed, turnSpeed);
        transform.Rotate(0, lookRotateDirection * Time.deltaTime, 0);*/

        if(lookInputVector.x == 0) {
            //transform.Rotate(0, lookRotateDirection * Time.deltaTime, 0);
            lookRotateDirection = 0;
        } else {
            lookRotateDirection += lookInputVector.x;
            lookRotateDirection = Mathf.Clamp(lookRotateDirection, -turnSpeed, turnSpeed);
            transform.Rotate(0, lookRotateDirection, 0);
        }

        // The longer looking in a direction the greater the value move in that direction
        lookVerticalDirection += lookInputVector.y;
        // Set the min and max angles to be able to look vertically
        lookVerticalDirection = Mathf.Clamp(lookVerticalDirection, -maxVerticalLookAngle, maxVerticalLookAngle);
        // Rotate the player to look towards 
        //transform.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);
        lookTransformPoint.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);


        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeed = moveSpeed * moveInputVector.y * Time.deltaTime;
        float strafeSpeed = moveSpeed * moveInputVector.x * Time.deltaTime;
        characterController.Move(forward * curSpeed + right * strafeSpeed);

        // If on the ground set velocity to 0 as not falling
        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else // not on the ground to have negative velocity increase by gravity over time to cause to fall.
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
