using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public string sceneToLoad;
    public Button replayButton;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            //SceneManager.LoadScene(sceneToLoad);
            Time.timeScale = 0;
            replayButton.gameObject.SetActive(true);
        }
    }

    public void WinLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }
}
