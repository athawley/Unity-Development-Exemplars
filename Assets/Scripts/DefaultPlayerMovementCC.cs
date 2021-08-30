using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefaultPlayerMovementCC : MonoBehaviour
{
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
        Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y);
        cc.Move(moveVector * Time.deltaTime * playerSpeed);
        cc.Move(Physics.gravity * Time.deltaTime);
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }
}
