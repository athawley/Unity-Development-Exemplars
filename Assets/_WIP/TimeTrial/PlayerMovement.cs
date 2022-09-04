using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 movementInput;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue iv) {
        movementInput = iv.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Create a 3D vector and use the x and y input of the user to move on the x and z axis
        We move on the z axis as this is the forward and back axis, y is vertical in 3D space.
        */
        Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);

        // Add force to the Vector to move it
        rb.AddForce(movement * speed);
    }
}
