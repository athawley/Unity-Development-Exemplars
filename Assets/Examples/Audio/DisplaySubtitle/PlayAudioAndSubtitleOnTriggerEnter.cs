using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAndSubtitleOnTriggerEnter : MonoBehaviour
{
    
    [SerializeField]
    AudioSource _soundEffect;
    [SerializeField]
    Canvas _subtitleCanvas;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player in range");
            _soundEffect.Play();
            _subtitleCanvas.gameObject.SetActive(true);
            StartCoroutine(RemoveSubtitle());
        }

        
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player out of range");
            _soundEffect.Stop();
            _subtitleCanvas.gameObject.SetActive(false);
        }
    }

    IEnumerator RemoveSubtitle() {
        yield return new WaitForSeconds(2);
        _subtitleCanvas.gameObject.SetActive(false);
    }
}
