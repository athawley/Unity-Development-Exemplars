using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VirtualCameraSwitch : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera[] vCams;
    public int currentCameraIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(CinemachineVirtualCamera c in vCams) {
            c.Priority = 0;
        }
        vCams[0].Priority = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire() {
        foreach(CinemachineVirtualCamera c in vCams) {
            c.Priority = 0;
        }
        currentCameraIndex = currentCameraIndex + 1;
        if(currentCameraIndex >= vCams.Length) {
            currentCameraIndex = 0;
        }
        vCams[currentCameraIndex].Priority = 10;
        
    }
}
