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
    public float moveSpeed = 5;
    public float walkSpeed = 25;
    public float runSpeed = 25;
    public float turnSpeed = 25;
    public float maxVerticalLookAngle = 80;
    public float lookVerticalDirection = 0;

    public float velocity = 0;
    public float gravity = 9.8f;

    public CharacterController characterController;

    void Start() {
        characterController = GetComponent<CharacterController>();
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
        transform.Rotate(0, lookInputVector.x * turnSpeed * Time.deltaTime, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeed = moveSpeed * moveInputVector.y;
        float strafeSpeed = moveSpeed * moveInputVector.x;
        characterController.SimpleMove(forward * curSpeed + right * strafeSpeed);

        // Build up rotation up/down input over time
        lookVerticalDirection += lookInputVector.y;
        // Clamp up/down rotation within logical bounds
        lookVerticalDirection = Mathf.Clamp(lookVerticalDirection, -maxVerticalLookAngle, maxVerticalLookAngle);
        // Apply rotation to player
        lookTransformPoint.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);

        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
