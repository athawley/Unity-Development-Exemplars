using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioSubtitleOnEnter : MonoBehaviour
{
    AudioSource _audioSource;
    bool _play = false;

    [SerializeField]
    Text subtitle;

    [SerializeField]
    string message = "Click";

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
            subtitle.gameObject.SetActive(true);
            subtitle.text = message;
        }
    }

    void Update() {
        if(!_audioSource.isPlaying) {
            _play = false;
            subtitle.gameObject.SetActive(false);
        }
    }
}
