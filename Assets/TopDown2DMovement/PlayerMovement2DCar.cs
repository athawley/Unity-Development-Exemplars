using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2DCar : MonoBehaviour
{
    float drift = 0.5f;
    Vector2 movement;
    Rigidbody2D rb;
    public float speed = 5;
    public float turnSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
        Debug.Log(movement.x + " - " + movement.y);
    }
 
    void FixedUpdate() {

        // Get Forward Velocity
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);

        // Get Right Velocity (drift)
        Vector2 rightDrift = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightDrift * drift;

        rb.AddForce(transform.up * speed * movement.y * Time.deltaTime, ForceMode2D.Force);
        rb.MoveRotation(rb.rotation + turnSpeed * -movement.x * Time.deltaTime);

    }
}