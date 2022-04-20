using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EngineMovement : MonoBehaviour
{
    public Transform leftEngineTransform;
    public Transform rightEngineTransform;
    public float _speed = 5.0f;
    Rigidbody shipBody;
    // Start is called before the first frame update
    void Start()
    {
        shipBody = GetComponent<Rigidbody>();
    }

    void OnLeftEngine() {
        shipBody.AddForceAtPosition(Vector3.forward * _speed, leftEngineTransform.position, ForceMode.Impulse);
        Debug.Log("Left pressed");
    }

    void OnRightEngine() {
        Debug.Log("Right pressed");
        shipBody.AddForceAtPosition(Vector3.forward * _speed, rightEngineTransform.position, ForceMode.Impulse);
    }

    void OnLeftSpin(InputValue iv) {
    
        
    }

    void OnRightSpin() {
        Debug.Log("Right pressed");
        shipBody.AddForceAtPosition(Vector3.forward * _speed, rightEngineTransform.position, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
