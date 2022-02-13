using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnPlayerJoined(PlayerInput pi) {
        Debug.Log("PlayerInput Joined " + pi.playerIndex);
        pi.gameObject.GetComponent<PlayerMovementCine3rdLocalMP>().CinemachineInputProvider.PlayerIndex = pi.playerIndex;
    }
}
