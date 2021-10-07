using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    /*
    void OnTriggerEnter(Collider col) {
        Debug.Log("Triggered");
        if(col.CompareTag("Respawn")) {
            gameObject.SetActive(false);
            Debug.Log("Respawn");
            transform.position = new Vector3(0, 20, 0);

            gameObject.SetActive(true);
        }
    }
    */

    void Update() {
        if(transform.position.y < -100) {
            gameObject.SetActive(false);
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
            gameObject.SetActive(true);
        }
    }
}
