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
        Transform a = pi.gameObject.transform.Find("PlayerAlpha");
        Transform b = pi.gameObject.transform.Find("PlayerBeta");
        targetGroup.AddMember(a, 3f, 5f);
        targetGroup.AddMember(b, 3f, 5f);
    }
}
