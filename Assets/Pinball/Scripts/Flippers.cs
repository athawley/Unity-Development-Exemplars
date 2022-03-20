using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flippers : MonoBehaviour
{
    public Transform LeftFlipper, RightFlipper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLaunchBall() {
        Debug.Log("Launch pressed");
    }

    void OnLeftFlipper() {
        Debug.Log("Left flipper pressed");
    }

    void OnRightFlipper() {
        Debug.Log("Right flipper pressed");
    }
}
