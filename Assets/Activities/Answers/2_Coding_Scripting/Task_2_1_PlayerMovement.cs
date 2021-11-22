using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Task_2_1_PlayerMovement : MonoBehaviour
{
    Vector2 movementInputVector; // Vector for player movement
    float speed = 5.0f;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Loaded");
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInputVector.x, 0.0f, movementInputVector.y);
        cc.SimpleMove(movement * speed);
    }

    public void OnFire()
    {
        Debug.Log("Fire!");
    }

    

    public void OnMove(InputValue iv) {
        movementInputVector = iv.Get<Vector2>();
    }
}
