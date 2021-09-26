using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D_TopDown_UDLR : MonoBehaviour
{
    // Object Variables
    Rigidbody2D rb;
    Vector2 movement;
    public float playerSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }
}
