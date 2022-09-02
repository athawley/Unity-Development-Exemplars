using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyStart : MonoBehaviour
{
    PlayerInputManager pi;
    public List<Transform> spawnLocations = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined(PlayerInput playerInput) {
        Debug.Log("A player joined");
        playerInput.gameObject.GetComponent<BALListicsPlayerManager>().spawnPoint = spawnLocations[playerInput.playerIndex];
    }
}
