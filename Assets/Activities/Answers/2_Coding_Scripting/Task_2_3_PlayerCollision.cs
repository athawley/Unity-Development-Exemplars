using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Task_2_3_PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Checkpoint") == true) {
            Debug.Log("Collided with a checkpoint. ID# " + col.gameObject.GetInstanceID().ToString());

            

            // Extension
            Color colour = Random.ColorHSV();
            
            Renderer _rend;
            if(col.gameObject.TryGetComponent<Renderer>(out _rend)) {
                Debug.Log("Here");
                _rend.material.color = colour;
            }
            

            //Destroy(col.gameObject);
        }
    }
}
