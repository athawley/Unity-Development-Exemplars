using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
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
        rb.AddForce(transform.up * speed * movement.y * Time.deltaTime, ForceMode2D.Force);
        rb.MoveRotation(rb.rotation + turnSpeed * -movement.x * Time.deltaTime);

    }
}