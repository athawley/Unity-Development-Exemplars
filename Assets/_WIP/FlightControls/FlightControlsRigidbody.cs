using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightControlsRigidbody : MonoBehaviour
{
    /*
    Thurst -> forward momentum
    Roll -> barrel roll around length of object (rotate around z axis) 
    Pitch -> pull and lower nose. (roatate around x axis)
    Yaw -> horizontal spin. (rotate around y axis)
    */
    [SerializeField]
    float thrust, roll, pitch, yaw;
    public float thrustSpeed = 5, rollSpeed = 25, pitchSpeed = 5, yawSpeed = 5;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddRelativeForce(transform.forward * thrust * thrustSpeed * Time.deltaTime,ForceMode.Acceleration);
        rb.AddRelativeForce(new Vector3(0,0,thrust) * thrustSpeed * Time.deltaTime,ForceMode.Acceleration);
        //transform.position += transform.forward * thrust;

        //transform.Rotate(new Vector3(pitch, 0, 0) * 5 * Time.deltaTime, Space.Self);

        //transform.Rotate(new Vector3(0, 0, -roll) * 50 * Time.deltaTime, Space.Self);

        //transform.Rotate(new Vector3(0, yaw, 0) * 5 * Time.deltaTime, Space.Self);

        rb.AddRelativeTorque(new Vector3(pitch, 0, 0).normalized * pitchSpeed * Time.deltaTime,ForceMode.Acceleration);

        rb.AddRelativeTorque(new Vector3(0, 0, -roll) * rollSpeed * Time.deltaTime,ForceMode.Acceleration);

        rb.AddRelativeTorque(new Vector3(0, yaw, 0) * yawSpeed * Time.deltaTime,ForceMode.Acceleration);

        
    }

    void OnThrustAndRoll(InputValue iv) {
        Vector2 tempV = iv.Get<Vector2>();
        thrust = tempV.y;
        yaw = tempV.x;
    }

    void OnPitchAndYaw(InputValue iv) {
        Vector2 tempV = iv.Get<Vector2>();
        pitch = tempV.y;
        roll = tempV.x;
    }
}
