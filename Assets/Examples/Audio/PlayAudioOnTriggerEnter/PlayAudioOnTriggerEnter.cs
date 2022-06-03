using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    
    [SerializeField]
    AudioSource _soundEffect;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player in range");
            _soundEffect.Play();
        }
    }
}
