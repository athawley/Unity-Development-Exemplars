using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveAndRotate : MonoBehaviour
{
    private float _rotate;
    private Vector2 _movementInput;
    private CharacterController _cc;

    public float PlayerSpeed = 5;
    public float RotationSpeed = 75;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    void OnMove(InputValue iv) {
        _movementInput = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        _rotate = iv.Get<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer() {
        Vector3 movement = new Vector3(_movementInput.x, 0.0f, _movementInput.y);

        movement = transform.forward * movement.z + transform.right * movement.x;

        _cc.Move(movement * Time.deltaTime * PlayerSpeed);

        _cc.Move(Physics.gravity * Time.deltaTime);
    }

    void RotatePlayer() {
        transform.Rotate(Vector3.up * _rotate * RotationSpeed * Time.deltaTime);
    }
}
