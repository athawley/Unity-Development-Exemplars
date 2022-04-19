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
    public float glide = 0f;
    public float thrustDeccelerationRate = 0.5f;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * thrust * thrustSpeed * Time.deltaTime,ForceMode.Impulse);
        //rb.AddRelativeForce(new Vector3(0,0,thrust) * thrustSpeed * Time.deltaTime,ForceMode.Impulse);
        //transform.position += transform.forward * thrust;

        //transform.Rotate(new Vector3(pitch, 0, 0) * 5 * Time.deltaTime, Space.Self);

        //transform.Rotate(new Vector3(0, 0, -roll) * 50 * Time.deltaTime, Space.Self);

        //transform.Rotate(new Vector3(0, yaw, 0) * 5 * Time.deltaTime, Space.Self);

        //rb.AddRelativeTorque(new Vector3(pitch, 0, 0).normalized * pitchSpeed * Time.deltaTime,ForceMode.Acceleration);

        //rb.AddRelativeTorque(new Vector3(0, 0, -roll).normalized * rollSpeed * Time.deltaTime,ForceMode.Acceleration);

        //rb.AddRelativeTorque(new Vector3(0, yaw, 0).normalized * yawSpeed * Time.deltaTime,ForceMode.Acceleration);

        rb.AddRelativeTorque(Vector3.back * Mathf.Clamp(roll, -1f, 1f) * rollSpeed * Time.deltaTime);
        rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(pitch, -1f, 1f) * pitchSpeed * Time.deltaTime);
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(yaw, -1f, 1f) * yawSpeed * Time.deltaTime);

        if(thrust != 0) {
            float currentThrust = thrust;
            //currentThrust = thrustSpeed;
            rb.AddRelativeForce(Vector3.forward * thrust * thrustSpeed * Time.deltaTime, ForceMode.Acceleration);
            glide = thrust;
        } else {
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustDeccelerationRate;
        }
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

    void OnFire() {
        // Reset rotation and velocity to 0
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
