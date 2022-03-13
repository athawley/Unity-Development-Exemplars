using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class DualCameraTwoCharacters : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;

    void OnPlayerJoined(PlayerInput pi)
    {

        Color c;
        int r = Random.Range(0,3);
        switch(r) {
            case 0:
                c = Color.red;
                break;
            case 1:
                c = Color.green;
                break;
            case 2:
                c = Color.blue;
                break;
            default:
                c = Color.black;
                break;
        }

        Transform a = pi.gameObject.transform.Find("PlayerAlpha");
        Transform b = pi.gameObject.transform.Find("PlayerBeta");
        LineRenderer l = pi.gameObject.transform.Find("Line").GetComponent<LineRenderer>();
        targetGroup.AddMember(a, 3f, 5f);
        targetGroup.AddMember(b, 3f, 5f);
        a.GetComponent<Renderer>().material.color = c;
        b.GetComponent<Renderer>().material.color = c;
        l.startColor = c;
        l.endColor = c;
    }
}
