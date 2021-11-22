using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_2_2_PlayerShoot : MonoBehaviour
{
    public GameObject bullet; // Store the bullet prefab
    public float bulletSpeed = 5.0f; // The speed of the bullet
    
    void OnFire() {

        // Create a bullet gameobject infront of the object this script is attached to
        GameObject go = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z +1), Quaternion.identity);
        
        // Check if there is a rigidbody on the prefab object
        Rigidbody rb;
        if(go.TryGetComponent<Rigidbody>(out rb)) {
            // Add forece to the prefab to move it forward
            rb.AddForce(transform.forward * bulletSpeed);
        }
    }
}
