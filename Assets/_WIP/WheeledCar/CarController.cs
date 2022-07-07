using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public WheelCollider lf, rf, lb, rb;
    public Vector2 movement;
    public float maxMotorTorque = 1000; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle = 30; // maximum steer angle the wheel can have
    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        float motor = maxMotorTorque * movement.y;
        float steering = maxSteeringAngle * movement.x;
        lf.steerAngle = steering;
        rf.steerAngle = steering;
        lb.motorTorque = motor;
        rb.motorTorque = motor;
    }
}
