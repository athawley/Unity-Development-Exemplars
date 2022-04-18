using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceflightControlsRigidbody : MonoBehaviour
{
    /*
    Thurst -> forward momentum
    Roll -> barrel roll around length of object (rotate around z axis) 
    Pitch -> pull and lower nose. (roatate around x axis)
    Yaw -> horizontal spin. (rotate around y axis)
    */
    [SerializeField]
    Transform thisShip;
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float turnSpeed = 60f, boostSpeed = 45f, pitch, yaw, roll, thrust;


    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Turn();
        Thrust();
    }

    void Turn() {
        thisShip.Rotate(pitch,yaw,roll);
    }

    void Thrust() {
        thisShip.position += thisShip.forward * boostSpeed * Time.deltaTime * thrust;
    }

    void OnThrustAndRoll(InputValue iv) {
        Vector2 tempV = iv.Get<Vector2>();
        thrust = turnSpeed * Time.deltaTime * tempV.y;
        yaw = turnSpeed * Time.deltaTime * tempV.x;
    }

    void OnPitchAndYaw(InputValue iv) {
        Vector2 tempV = iv.Get<Vector2>();
        pitch = turnSpeed * Time.deltaTime * tempV.y;
        roll = turnSpeed * Time.deltaTime * tempV.x;
    }
}
