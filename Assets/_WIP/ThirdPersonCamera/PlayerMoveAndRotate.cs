using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveAndRotate : MonoBehaviour
{
    private float _rotate;
    private Vector2 _movement;
    private CharacterController _cc;
    public float PlayerSpeed = 5;
    public float RotationSpeed = 75;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer() {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeed = PlayerSpeed * _movement.y * Time.deltaTime;
        float strafeSpeed = PlayerSpeed * _movement.x * Time.deltaTime;
        _cc.Move(forward * curSpeed + right * strafeSpeed);

        _cc.Move(Physics.gravity * Time.deltaTime);
    }

    void RotatePlayer() {
        transform.Rotate(Vector3.up * _rotate * RotationSpeed * Time.deltaTime);
    }

    void OnMove(InputValue iv) {
        _movement = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        _rotate = iv.Get<Vector2>().x;
    }
}
