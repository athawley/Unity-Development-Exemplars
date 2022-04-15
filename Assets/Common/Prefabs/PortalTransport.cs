using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    public Transform exitLocation;

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            // Player collided, teleport to exit location
            col.gameObject.SetActive(false);
            col.gameObject.transform.position = exitLocation.position;
            col.gameObject.SetActive(true);
        }
    }
}
