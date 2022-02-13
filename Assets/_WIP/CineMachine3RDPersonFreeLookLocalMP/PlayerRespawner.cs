using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    public Transform RespawnPoint;
    
    void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered");
        if(other.CompareTag("Player")) {
            Debug.Log("Respawn");
            other.gameObject.transform.gameObject.SetActive(false);

            other.gameObject.transform.position = RespawnPoint.position;

            other.gameObject.transform.gameObject.SetActive(true);
        }
    }
}
