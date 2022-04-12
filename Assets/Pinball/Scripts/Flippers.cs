using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flippers : MonoBehaviour
{
    public Transform LeftFlipper, RightFlipper;
    public static bool LeftFlipperPressed = false;
    public static bool RightFlipperPressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //RightFlipper.GetComponent<Animator>().enabled = false;
        RightFlipper.GetComponent<Animator>().Play("FlipperAnimation",-1,0f);
        
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
        LeftFlipper.GetComponent<Animator>().Play("FlipperAnimation", -1, 0f);
    }

    void OnRightFlipper() {
        Debug.Log("Right flipper pressed");
        //RightFlipper.GetComponent<Animator>().enabled = true;
        RightFlipper.GetComponent<Animator>().Play("FlipperAnimation", -1, 0f);
        
    }
}
