using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public Vector2 movement;
    public float movementSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        cc.Move(new Vector3(movement.x , 0.0f, movement.y) 
            * movementSpeed * Time.deltaTime);
    }
}
