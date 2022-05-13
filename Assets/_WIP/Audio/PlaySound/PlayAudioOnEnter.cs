using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    AudioSource _audioSource;
    bool _play = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && _play == false) {
            // Play Audio
            _play = true;
            _audioSource.Play();
        }
    }

    void Update() {
        if(!_audioSource.isPlaying) {
            _play = false;
        }
    }
}
