using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XYZPlayerMovement : MonoBehaviour
{
    float _xMovement, _yMovement, _zMovement;
    public float speed = 5;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue iv) {
        Vector2 tempInput = iv.Get<Vector2>();

        _xMovement = tempInput.x;
        _zMovement = tempInput.y;
    }

    void OnMoveUpAndDown(InputValue iv) {
        _yMovement = iv.Get<float>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInputVector = new Vector3(_xMovement, _yMovement, _zMovement);

        rb.MovePosition(transform.position + movementInputVector * Time.deltaTime * speed);
    }
}
