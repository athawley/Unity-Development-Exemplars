using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D_TopDown_UDLR_Animation : MonoBehaviour
{
    // Object Variables
    Rigidbody2D rb;
    Vector2 movement;
    public float playerSpeed = 5;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
        animator.SetInteger("xInput", (int)movement.x);
        animator.SetInteger("yInput", (int)movement.y);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }
}
