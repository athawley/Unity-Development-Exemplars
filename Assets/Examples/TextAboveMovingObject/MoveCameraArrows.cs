using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCameraArrows : MonoBehaviour
{
    public Vector2 lookInputVector;

    // Movement and Look Variables
    public float moveSpeed = 25;
    public float turnSpeed = 200;

    public float lookRotateDirection = 0;
    public float maxVerticalLookAngle = 80;
    public float lookVerticalDirection = 0;
 
    public float rotate;
    public Vector2 movement;
    private CharacterController cc;
    public float playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        lookRotateDirection += lookInputVector.x;
        lookRotateDirection = Mathf.Clamp(lookRotateDirection, -turnSpeed, turnSpeed);
        transform.Rotate(0, lookRotateDirection * Time.deltaTime, 0);
        // The longer looking in a direction the greater the value move in that direction
        lookVerticalDirection += lookInputVector.y;
        // Set the min and max angles to be able to look vertically
        lookVerticalDirection = Mathf.Clamp(lookVerticalDirection, -maxVerticalLookAngle, maxVerticalLookAngle);
        // Rotate the player to look towards 
        transform.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);


        Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y);
        cc.Move(moveVector * Time.deltaTime * playerSpeed);
        //cc.Move(Physics.gravity * Time.deltaTime);
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        lookInputVector = iv.Get<Vector2>();

        Debug.Log(rotate);
    }
}
