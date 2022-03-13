using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class PlayerJoinCameraManager : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;

    void OnPlayerJoined(PlayerInput pi) {
        targetGroup.AddMember(pi.gameObject.transform, 3f, 5f);
    }
}
