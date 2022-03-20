using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyThroughMovement : MonoBehaviour
{
    float _xMovement, _yMovement, _zMovement;
    public float speed = 5;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(_xMovement, _zMovement, _yMovement);
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    void OnMove(InputValue iv) {
        Vector2 tempImputVector = iv.Get<Vector2>();

        _xMovement = tempImputVector.x;
        _yMovement = tempImputVector.y;
    }

    void OnMoveUp() {
        _zMovement = 1;
    }
    

    void OnMoveUpAndDown(InputValue iv) {
        Debug.Log("Up and Down detected: " + iv.Get<float>());
        _zMovement = iv.Get<float>();
    }
}
